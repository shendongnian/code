    public class RPG{
        Player player;
        Map ReferenceMap, ActualMap;
        public static void Main(){
            player = new Player();  //Use the default constructor or another constructor
                                    //to set the starting coords of the player
            
            ActualMap = new Map();  //Load the data into the map
            
            ReferenceMap = ActualMap;  //Since they are the same for now, just store
                                       //the data already there
            while(true){
                //Add a delay using Stopwatch, preferably 1/60th of a second
                Update();
            }
        }
        
        public void Update(){
            Player.Update();
            ActualMap.Update();
            ActualMap.Draw();
        }
    }
