    [XmlRoot("notes")]
    public class NoteList : List<Note>
    {
        // Set this to 'default' or 'preserve'.
        [XmlAttribute("space", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string space = "preserve";
        private List<string> _categories = null;
        public List<string> Categories
        {
            get
            {
                if (_categories == null)
                {
                    foreach (Note n in this)
                    {
                        if (!_categories.Contains(n.Category))
                            _categories.Add(n.Category);
                    }
                }
                return _categories;
            }
        }
        public static void Save(NoteList noteList, string NotesFilePath)
        {
            if (noteList == null) return;
            XmlSerializer serializer = new XmlSerializer(typeof(NoteList));
              
            string tmpPath = NotesFilePath + ".tmp";
            using (System.IO.FileStream fs = new FileStream(tmpPath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, noteList);
                fs.Close();
            }
            if (File.Exists(tmpPath))
            {
                if (File.Exists(NotesFilePath))
                {
                    string oldFile = NotesFilePath + ".bak";
                    if (File.Exists(oldFile)) File.Delete(oldFile);
                    File.Move(NotesFilePath, oldFile);
                }
                File.Move(tmpPath, NotesFilePath);
            }
        }
        public static NoteList Load(string NotesFilePath)
        {
            if (!System.IO.File.Exists(NotesFilePath))
                return null;
            NoteList noteList = new NoteList();
            XmlSerializer serializer = new XmlSerializer(noteList.GetType());
            using (FileStream fs = new FileStream(NotesFilePath, FileMode.Open, FileAccess.Read))
            {
                noteList = (NoteList)serializer.Deserialize(fs);
                fs.Close();
            }
            return noteList;
        }
    }
