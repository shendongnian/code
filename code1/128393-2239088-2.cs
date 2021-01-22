    public class activity
    {
        public activity(string message, object action_link)
        {
            Message = message;
            Action_Link = action_link;
        }
        public string Message { get; set; }
        public object Action_Link { get; set; }
    }
    public class action_link
    {
        public string Text { get; set; }
        public string Href { get; set; }
        public action_link(string text, string href)
        {
            Text = text;
            Href = href;
        }
    }
