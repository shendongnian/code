    public class DesktopDTO
        {
            public DesktopDTO() { }
            public DesktopDTO(string title, Guid otherId)
            {
                Id = Guid.NewGuid().ToString();
                Title = title;
                OtherId = otherId;
            }
            public string Id { get; set; }
            public string Title { get; set; }
            public Guid OtherId { get; set; }
    
        }
