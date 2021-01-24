    class Program
    {
        static void Main(string[] args)
        {
            var listOfRooms = new List<Room>() { new SingleSharingRoom(1), new StorageRoom(), new TwinSharingRoom(2) };
            foreach(var room in listOfRooms)
            {
                if(room is IMaximumCapacity)
                {
                    room.BookTheRoom();
                }
            }
            Console.ReadLine();
        }
    }
