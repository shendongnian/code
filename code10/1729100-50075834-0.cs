    public class Hotel
    {
        private HashSet<int> avalibe;
        private HashSet<int> busy;
        
        //constructor to set number of rooms
        public Hotel(int totalNumberOfRooms)
        {
            avalibe = new HashSet<int>();
            for (int i = 1; i <= totalNumberOfRooms; i++)
                avalibe.Add(i);
            busy = new HashSet<int>();
        }
        //Returns true if room is available
        public bool hasRoomsAvailable()
        {
            return avalibe.Count > 0;
        }
        //Time Complexity: O(1)
        //Checks if there's at least one room available and it reserves it
        public int checkIn()
        {
            if (hasRoomsAvailable())
            {
                var result = avalibe.First();
                avalibe.Remove(result);
                busy.Add(result);
                return result;
            }
            else
                return -1;
        }
        //Time Complexity: O(1)
        //Check out method
        public void checkOut(int roomNumber)
        {
            if (!busy.Contains(roomNumber))
            {
                Console.WriteLine("Incorrect room number : {0}", roomNumber);
                return;
            }
            busy.Remove(roomNumber);
            avalibe.Add(roomNumber);
        }
        
    }
