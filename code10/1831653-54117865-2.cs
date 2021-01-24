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
            // use a better variable name since "dialogs" is also a field of it
            DialogContainer dialogContainer;
    
            // use "using" for disposables
            using(StringReader reader = new StringReader(_xml.text))
            {
                dialogContainer = serializer.Deserialize(reader) as DialogContainer;
            }
            // reset dictionary
            dialogContainer.IdToText.Clear();
            foreach(var entry in dialogContainer.dialogs)
            {
                dialogContainer.IdToText.Add(entry.id, entry.text);
            }
            return dialogContainer;
        }
    }
