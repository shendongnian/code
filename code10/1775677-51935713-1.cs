    public struct AppData
    {
        public string Subject { get; }
        public DateTime From { get; }      
        public DateTime To { get; }       
        public string Location { get; }      
        public string Categories { get; }      
        public string Username { get; }
        public AppData(AppointmentItem appItem, string username)
        {
            Subject = appItem.Subject;
            From = appItem.Start;
            To = appItem.End;
            Location = appItem.Location;
            Categories = appItem.Categories;
            Username = username;
        }
    }
