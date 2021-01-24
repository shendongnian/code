    [XmlRoot("DialogCollection")]
    public class DialogContainer
    {
        [XmlArray("Dialogs")]
        [XmlArrayItem("Dialog")]
        public List<Dialog> dialogs = new List<Dialog>();
        public Dictionary<string, string> IdToText = new Dictionary<string, string>();
    
        public static DialogContainer Load(string path)
        {
            TextAsset _xml = Resources.Load<TextAsset>(path);
    
            XmlSerializer serializer = new XmlSerializer(typeof(DialogContainer));
    
            StringReader reader = new StringReader(_xml.text);
    
            DialogContainer dialogs = serializer.Deserialize(reader) as DialogContainer;
    
    
            reader.Close();
            // reset dictionary
            dialogs.IdToText.Clear();
            foreach(var entry in dialogs.dialogs)
            {
                dialogs.IdToText.Add(entry.id, entry.text);
            }
            return dialogs;
        }
    }
