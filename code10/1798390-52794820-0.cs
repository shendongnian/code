    public abstract Room
    {
        // Need to be assigned in constructor.
        protected int RoomNumber { get; set; } 
        protected int PositionX { get; set; }
        protected int PositionY { get; set; }
    
        // Always the same at the start
        protected List<Guest> GuestsInRoom { get; set; }
        protected string ImageFilePath { get; set; }
        protected Room(int roomNumber, int positionX, int positionY)
        {
            RoomNumber = roomNumber;
            PositionX = positionX;
            PositionY = positionY;
            GuestsInRoom = new List<Guest>();
        }
    }
    
    public class Bedroom : Room
    {
        private string Classification { get; set; }
        public Bedroom(string classification, int roomNumber, int positionX, int positionY) : base(roomNumber, positionX, positionY)
        {
            // Assign/instantiate all properties.
            Classification = classification;
        }
    }
