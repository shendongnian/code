    public abstract class Room
    {
        public abstract void BookTheRoom();
    }
    interface IMaximumCapacity
    {
        int MaximumCapacity { get; set; }
    }
    public class StorageRoom : Room
    {
        public override void BookTheRoom()
        {
            Console.WriteLine("Storage room booked to store the items.");
        }
    }
    public class TwinSharingRoom : Room,IMaximumCapacity
    {
        public TwinSharingRoom(int capacity)
        {
            MaximumCapacity = capacity;
        }
        public int MaximumCapacity { get; set; }
        public override void BookTheRoom()
        {
            Console.WriteLine("Twinsharing room booked.");
        }
    }
    public class SingleSharingRoom : Room, IMaximumCapacity
    {
        public SingleSharingRoom(int capacity)
        {
            MaximumCapacity = capacity;
        }
        public int MaximumCapacity { get; set; }
        public override void BookTheRoom()
        {
            Console.WriteLine("Single sharing room booked.");
        }
    }
