    private string text;
    [XmlText]
    public string Text {
        get { return text; }
        set 
        {
            Regex r = new Regex("(?<!\r)\n");
            text = r.Replace(value, "\r\n"); 
        }
    }
