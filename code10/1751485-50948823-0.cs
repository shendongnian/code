    [Table("Room")]
    public class Room
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string RoomName { get; set; }
        public string NFC_UId { get; set; }
        [Ignore]
        public List<Switch> RoomSwitches { get; set; } //note the get and set instead of new list
        public Room()
        {
        }
        
        public getswitches(){} <---
    }
