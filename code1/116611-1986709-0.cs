    public class House
    {  
        private readonly Hall hall = new Hall();
        private readonly Kitchen kitchen = new Kitchen();
    
        // etc
    
        public House()
        {
            hall.AddAdjacentRoom(kitchen);
            // etc
        }
    
    }
