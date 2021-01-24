    public class LogEntry
    {
        public LogEntry(DateTime dateTime, int index, string message, Color textColor)
        {
            DateTime = dateTime;
            Index = index;
            Message = message;
            TextColor = new SolidColorBrush(textColor);
            TextColor.Freeze();
        }
    
        public DateTime DateTime { get; set; }
    
        public int Index { get; set; }
    
        public string Message { get; set; }
    
        public SolidColorBrush TextColor { get; set; }
    }
