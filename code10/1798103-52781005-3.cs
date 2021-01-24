    public class Player{
        public int X, Y;
        private int NewX, NewY;
        private int PrevX, PrevY;
        
        public Player(){
            X = 10;
            Y = 10;
            NewX = 0;
            NewY = 0;
            PrevX = 0;
            PrevY = 0;
        }
        
        //Add other constructors to initialize the coordinates
        public void Update(){
            //Call this method in `Main()` in a loop.  Make sure to add a delay between each call!
            PrevX = X;
            PrevY = Y;
            
            ConsoleKeyInfo input = Console.ReadKey(true);
            switch(input.KeyChar){
                case 'w':
                    NewX = X;
                    NewY = Y - 1;
                    break;
                case 'a':
                    NewX = X - 1;
                    NewY = Y;
                    break;
                case 's':
                    NewX = X;
                    NewY = Y + 1;
                    break;
                case 'd':
                    NewX = X + 1;
                    NewY = Y;
            }
            
            //Add code to restrict the player to the window
            
            if(RPG.ReferenceMap[NewX][NewY] == '~'){  //Water tile
                NewX = X;
                NewY = Y;
            }
            
            //Check for other tiles the player should not walk on
            
            X = NewX;
            Y = NewY;
        }
    }
