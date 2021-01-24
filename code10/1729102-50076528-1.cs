    public class Hotel
    {
        private bool[] available;
        private int totalNumberOfRooms;        
        // constructor to set number of rooms
        public Hotel(int totalNumberOfRooms)
        {
            this.totalNumberOfRooms = totalNumberOfRooms;
            available = new bool[totalNumberOfRooms];
            for (int i = 0; i < totalNumberOfRooms; i++)   
                available[i] = true;
        }
        //Returns true if room is available
        public bool hasRoomsAvailable()
        {
            return available.Any(room => room);
        }
        //Time Complexity: O(1)
        //Checks if there's at least one room available and it reserves it
        public int checkIn()
        {
			for(int room = 0; room < totalNumberOfRooms; room++)
			{
				if (available[room])
				{
					available[room] = false;
					return room + 1;
				}
			}
            return -1;
        }
        //Time Complexity: O(1)
        //Check out method
        public void checkOut(int roomNumber)
        {
            if (roomNumber <= totalNumberOfRooms && roomNumber > 0)
            {
                if (available[roomNumber - 1] == false)
                {
                    available[roomNumber - 1] = true;
                    Console.WriteLine("Check out room : {0}", roomNumber);
                }
                else
                    Console.WriteLine("Invalid Check Out : {0}", roomNumber);
            }
            else
                Console.WriteLine("Incorrect room number : {0}", roomNumber);
        }
	}
<!---->
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
        hotel.checkOut(1);
        roomNum = hotel.checkIn();
        Console.WriteLine("Room Allocated is: {0}", roomNum);
        Console.ReadLine();
    }
