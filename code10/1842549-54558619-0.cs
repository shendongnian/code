    public class SaisieDateEventArgs : EventArgs
    {
        public string Date { get; }
        public class SaisieDateEventArgs(string date)
        {
            Date = date;
        }
    }
