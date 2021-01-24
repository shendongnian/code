    public abstract class Room
    {
        public int? MaximumCapacity;
        public bool CurrentPosition;
        public abstract void BookTheRoom();
    }
    public class StorageRoom : Room
    {
        public override void BookTheRoom()
        {
            Console.WriteLine("Storage room booked to store the items.");
        }
    }
    public class TwinSharingRoom : Room
    {
        //int MaximumCapacity;
        //bool CurrentPosition;
        public TwinSharingRoom(int capacity)
        {
            MaximumCapacity = capacity;
        }
        public override void BookTheRoom()
        {
            Console.WriteLine("Twinsharing room booked.");
        }
    }
    public class SingleSharingRoom : Room
    {
        //int MaximumCapacity;
        //bool CurrentPosition;
        public SingleSharingRoom(int capacity)
        {
            MaximumCapacity = capacity;
        }
        public override void BookTheRoom()
        {
            Console.WriteLine("Single sharing room booked.");
        }
    }
