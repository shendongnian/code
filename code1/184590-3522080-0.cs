    public class CustomDisplayName : DisplayNameAttribute
    {
        public CustomDisplayName()
        {
            this.DisplayName = MyXmlReader.Read(DisplayName);
        }
    }
