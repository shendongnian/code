    [XmlRoot("DialogCollection")]
    public class DialogContainer
    {
        [XmlArray("Dialogs")]
        [XmlArrayItem("Dialog")]
        public List<Dialog> dialogs = new List<Dialog>();
    
        public static DialogContainer Load(string path)
        {
            TextAsset _xml = Resources.Load<TextAsset>(path);
    
            XmlSerializer serializer = new XmlSerializer(typeof(DialogContainer));
    
            StringReader reader = new StringReader(_xml.text);
    
            DialogContainer dialogs = serializer.Deserialize(reader) as DialogContainer;
    
            reader.Close();
    
            return dialogs;
        }
        public string IdtoText(string id)
        {
            var foundDialog = dialogs.FirstOrDefault(dialog => string.Equals(dialog.id, id));
 
            //         here you can decide whether to        |
            //         return null or "" if no element found v 
            return foundDialog != null ? foundDialog.text : "";
        }
    }
