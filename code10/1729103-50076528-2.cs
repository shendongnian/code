    public class Hotel
    {
        private Queue<int> rooms;
        private int totalNumberOfRooms;        
        // constructor to set number of rooms
        public Hotel(int totalNumberOfRooms)
        {
            this.totalNumberOfRooms = totalNumberOfRooms;
            rooms = new Queue<int>();
            for (int i = 1; i <= totalNumberOfRooms; i++)   
                rooms.Enqueue(i);
        }
        //Returns true if room is available
        public bool hasRoomsAvailable()
        {
            return rooms.Count > 0;
        }
        //Time Complexity: O(1)
        //Checks if there's at least one room available and it reserves it
        public int checkIn()
        {
			if (rooms.Count > 0)
				return rooms.Dequeue();
            return -1;
        }
        //Time Complexity: O(1)
        //Check out method
        public void checkOut(int roomNumber)
        {
            if (roomNumber <= totalNumberOfRooms && roomNumber > 0)
            {
				Console.WriteLine("Check out room : {0}", roomNumber);
                rooms.Enqueue(roomNumber);
            }
            else
                Console.WriteLine("Incorrect room number : {0}", roomNumber);
        }
	}
    public static void Main(string[] args)
    {
        //Create an instance of Hotel with 5 rooms
        Hotel hotel = new Hotel(5);
        int roomNum = -1;
        if (hotel.hasRoomsAvailable())
        {
            roomNum = hotel.checkIn();
            Console.WriteLine("Room Allocated is: {0}", roomNum);
            roomNum = hotel.checkIn();
            Console.WriteLine("Room Allocated is: {0}", roomNum);
            roomNum = hotel.checkIn();
            Console.WriteLine("Room Allocated is: {0}", roomNum);
            roomNum = hotel.checkIn();
            Console.WriteLine("Room Allocated is: {0}", roomNum);
            roomNum = hotel.checkIn();
            Console.WriteLine("Room Allocated is: {0}", roomNum);
        }
        hotel.checkOut(4);
		hotel.checkOut(2);
        roomNum = hotel.checkIn();
		Console.WriteLine("Room Allocated is: {0}", roomNum);
		
		roomNum = hotel.checkIn();
        Console.WriteLine("Room Allocated is: {0}", roomNum);
        //pause program output on console
        Console.ReadLine();
    }
