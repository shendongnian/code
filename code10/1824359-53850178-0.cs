    public class Rooms
    {
            public Streams room1{ get; set; }
            public Streams room2{ get; set; }
    }
    Rooms r = JsonConvert.DeserializeObject<Rooms>(jsonstring);
