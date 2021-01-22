    using System.Runtime.InteropServices;
    using System.Xml;
    using System.Diagnostics;
    using System.IO;
    using System.Drawing;
    using Microsoft.Office.Interop.Word;
    public class OpenXmlEmbeddedObject
    {
        #region Constants
        private const string _defaultOleContentType = "application/vnd.openxmlformats-officedocument.oleObject";
        private const string _oleObjectDataTag = "application/vnd";
        private const string _oleImageDataTag = "image/x-emf";
        #endregion Constants
        #region Member Variables
        private static FileInfo _fileInfo;
        private static string _filePathAndName;
        private static bool _displayAsIcon;
        private static bool _objectIsPicture;
        private object _objectMissing = System.Reflection.Missing.Value;
        private object _objectFalse = false;
        private object _objectTrue = true;
        #endregion Member Variables
        #region Properties
        /// <summary>
        /// The File Type, as stored in Registry (Ex: a GIF Image = 'giffile')
        /// </summary>
        public string FileType
        {
            get
            {
                if (String.IsNullOrEmpty(_fileType) && _fileInfo != null)
                {
                    _fileType = GetFileType(_fileInfo, false);
                }
                return _fileType;
            }
        }
        private string _fileType;
        /// <summary>
        /// The File Context Type, as storered in Registry (Ex: a GIF Image = 'image/gif')
        /// * Is converted into the 'Default Office Context Type' for non-office files
        /// </summary>
        public string FileContentType
        {
            get
            {
                if (String.IsNullOrEmpty(_fileContentType) && _fileInfo != null)
                {
                    _fileContentType = FileHelper.GetFileContentType(_fileInfo);
                    if (!_fileContentType.Contains("officedocument"))
                    {
                        _fileContentType = _defaultOleContentType;
                    }
                }
                return _fileContentType;
            }
        }
        private string _fileContentType;
        public bool ObjectIsOfficeDocument
        {
            get { return FileContentType != _defaultOleContentType; }
        }
        public bool ObjectIsPicture
        {
            get { return _objectIsPicture; }
        }
        public string OleObjectBinaryData
        {
            get { return _oleObjectBinaryData; }
            set { _oleObjectBinaryData = value; }
        }
        private string _oleObjectBinaryData;
        public string OleImageBinaryData
        {
            get { return _oleImageBinaryData; }
            set { _oleImageBinaryData = value; }
        }
        private string _oleImageBinaryData;
        /// <summary>
        /// The OpenXml information for the Word Application that is created (Make-Shoft Code Reflector)
        /// </summary>
        public string WordOpenXml
        {
            get { return _wordOpenXml; }
            set { _wordOpenXml = value; }
        }
        private String _wordOpenXml;
        /// <summary>
        /// The XmlDocument that is created based on the OpenXml Data from WordOpenXml
        /// </summary>
        public XmlDocument OpenXmlDocument
        {
            get
            {
                if (_openXmlDocument == null && !String.IsNullOrEmpty(WordOpenXml))
                {
                    _openXmlDocument = new XmlDocument();
                    _openXmlDocument.LoadXml(WordOpenXml);
                }
                return _openXmlDocument;
            }
        }
        private XmlDocument _openXmlDocument;
        /// <summary>
        /// The XmlNodeList, for all Nodes containing 'binaryData'
        /// </summary>
        public XmlNodeList BinaryDataXmlNodesList
        {
            get
            {
                if (_binaryDataXmlNodesList == null && OpenXmlDocument != null)
                {
                    _binaryDataXmlNodesList = OpenXmlDocument.GetElementsByTagName("pkg:binaryData");
                }
                return _binaryDataXmlNodesList;
            }
        }
        private XmlNodeList _binaryDataXmlNodesList;
        /// <summary>
        /// Icon Object for the file
        /// </summary>
        public Icon ObjectIcon
        {
            get
            {
                if (_objectIcon == null)
                {
                    _objectIcon = Enterprise.Windows.Win32.Win32.GetLargeIcon(_filePathAndName);
                }
                return _objectIcon;
            }
        }
        private Icon _objectIcon;
        /// <summary>
        /// File Name for the Icon being created
        /// </summary>
        public string ObjectIconFile
        {
            get
            {
                if (String.IsNullOrEmpty(_objectIconFile))
                {
                    _objectIconFile = String.Format("{0}.ico", _filePathAndName.Replace(".", ""));
                }
                return _objectIconFile;
            }
        }
        private string _objectIconFile;
        /// <summary>
        /// Gets the original height and width of the emf file being created
        /// </summary>
        public string OleImageStyle
        {
            get
            {
                if (String.IsNullOrEmpty(_oleImageStyle) && !String.IsNullOrEmpty(WordOpenXml))
                {
                    XmlNodeList xmlNodeList = OpenXmlDocument.GetElementsByTagName("v:shape");
                    if (xmlNodeList != null && xmlNodeList.Count > 0)
                    {
                        foreach (XmlAttribute attribute in xmlNodeList[0].Attributes)
                        {
                            if (attribute.Name == "style")
                            {
                                _oleImageStyle = attribute.Value;
                            }
                        }
                    }
                }
                return _oleImageStyle;
            }
            set { _oleImageStyle = value; }
        }
        private string _oleImageStyle;
        #endregion Properties
        #region Constructor
        /// <summary>
        /// Generates binary information for the file being passed in
        /// </summary>
        /// <param name="fileInfo">The FileInfo object for the file to be embedded</param>
        /// <param name="displayAsIcon">Whether or not to display the file as an Icon (Otherwise it will show a snapshot view of the file)</param>
        public OpenXmlEmbeddedObject(FileInfo fileInfo, bool displayAsIcon)
        {
            _fileInfo = fileInfo;
            _filePathAndName = fileInfo.ToString();
            _displayAsIcon = displayAsIcon;
            SetupOleFileInformation();
        }
        #endregion Constructor
        #region Methods
        /// <summary>
        /// Creates a temporary Word App in order to add an OLE Object, get's the OpenXML data from the file (similar to the Code Reflector info)
        /// </summary>
        private void SetupOleFileInformation()
        {
            Microsoft.Office.Interop.Word.Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            
            Microsoft.Office.Interop.Word.Document wordDocument = wordApplication.Documents.Add(ref _objectMissing, ref _objectMissing,
                ref _objectMissing, ref _objectMissing);
            object iconObjectFileName = _objectMissing;
            object objectClassType = FileType;
            object objectFilename = _fileInfo.ToString();
            Microsoft.Office.Interop.Word.InlineShape inlineShape = null;
            if (_displayAsIcon)
            {
                if (ObjectIcon != null)
                {
                    using (FileStream iconStream = new FileStream(ObjectIconFile, FileMode.Create))
                    {
                        ObjectIcon.Save(iconStream);
                        iconObjectFileName = ObjectIconFile;
                    }
                }
                object objectIconLabel = _fileInfo.Name;
                inlineShape = wordDocument.InlineShapes.AddOLEObject(ref objectClassType,
                    ref objectFilename, ref _objectFalse, ref _objectTrue, ref iconObjectFileName,
                    ref _objectMissing, ref objectIconLabel, ref _objectMissing);
            }
            else
            {
                try
                {
                    Image image = Image.FromFile(_fileInfo.ToString());
                    _objectIsPicture = true;
                    OleImageStyle = String.Format("height:{0}pt;width:{1}pt", image.Height, image.Width);
                    wordDocument.InlineShapes.AddPicture(_fileInfo.ToString(), ref _objectMissing, ref _objectTrue, ref _objectMissing);
                }
                catch
                {
                    inlineShape = wordDocument.InlineShapes.AddOLEObject(ref objectClassType,
                        ref objectFilename, ref _objectFalse, ref _objectFalse, ref _objectMissing, ref _objectMissing,
                        ref _objectMissing, ref _objectMissing);
                }
            }
            WordOpenXml = wordDocument.Range(ref _objectMissing, ref _objectMissing).WordOpenXML;
            if (_objectIsPicture)
            {
                OleObjectBinaryData = GetPictureBinaryData();
                OleImageBinaryData = GetPictureBinaryData();
            }
            else
            {
                OleObjectBinaryData = GetOleBinaryData(_oleObjectDataTag);
                OleImageBinaryData = GetOleBinaryData(_oleImageDataTag);
            }
            // Not sure why, but Excel seems to hang in the processes if you attach an Excel file…
            // This kills the excel process that has been started < 15 seconds ago (so not to kill the user's other Excel processes that may be open)
            if (FileType.StartsWith("Excel"))
            {
                Process[] processes = Process.GetProcessesByName("EXCEL");
                foreach (Process process in processes)
                {
                    if (DateTime.Now.Subtract(process.StartTime).Seconds <= 15)
                    {
                        process.Kill();
                        break;
                    }
                }
            }
            wordDocument.Close(ref _objectFalse, ref _objectMissing, ref _objectMissing);
            wordApplication.Quit(ref _objectMissing, ref _objectMissing, ref _objectMissing);
        }
        /// <summary>
        /// Gets the binary data from the Xml File that is associated with the Tag passed in
        /// </summary>
        /// <param name="binaryDataXmlTag">the Tag to look for in the OpenXml</param>
        /// <returns></returns>
        private string GetOleBinaryData(string binaryDataXmlTag)
        {
            string binaryData = null;
            if (BinaryDataXmlNodesList != null)
            {
                foreach (XmlNode xmlNode in BinaryDataXmlNodesList)
                {
                    if (xmlNode.ParentNode != null)
                    {
                        foreach (XmlAttribute attr in xmlNode.ParentNode.Attributes)
                        {
                            if (String.IsNullOrEmpty(binaryData) && attr.Value.Contains(binaryDataXmlTag))
                            {
                                binaryData = xmlNode.InnerText;
                                break;
                            }
                        }
                    }
                }
            }
            return binaryData;
        }
        /// <summary>
        /// Gets the image Binary data, if the file is an image
        /// </summary>
        /// <returns></returns>
        private string GetPictureBinaryData()
        {
            string binaryData = null;
            if (BinaryDataXmlNodesList != null)
            {
                foreach (XmlNode xmlNode in BinaryDataXmlNodesList)
                {
                    binaryData = xmlNode.InnerText;
                    break;
                }
            }
            return binaryData;
        }
        /// <summary>
        /// Gets the file type description ("Application", "Text Document", etc.) for the file.
        /// </summary>
        /// <param name="fileInfo">FileInfo containing extention</param>
        /// <returns>Type Description</returns>
        public static string GetFileType(FileInfo fileInfo, bool returnDescription)
        {
            if (fileInfo == null)
            {
                throw new ArgumentNullException("fileInfo");
            }
            string description = "File";
            if (string.IsNullOrEmpty(fileInfo.Extension))
            {
                return description;
            }
            description = string.Format("{0} File", fileInfo.Extension.Substring(1).ToUpper());
            RegistryKey typeKey = Registry.ClassesRoot.OpenSubKey(fileInfo.Extension);
            if (typeKey == null)
            {
                return description;
            }
            string type = Convert.ToString(typeKey.GetValue(string.Empty));
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(type);
            if (key == null)
            {
                return description;
            }
            if (returnDescription)
            {
                description = Convert.ToString(key.GetValue(string.Empty));
                return description;
            }
            else
            {
                return type;
            }
        }
        #endregion Methods
    }
