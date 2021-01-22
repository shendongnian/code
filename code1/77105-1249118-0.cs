    public struct Game {
       private int TeamA;
       private int TeamB;
       private bool GamePlayed;
    
       // I am adding this to quickly see what team is playing. I used this for debugging
       // purposes to make sure the same team doesn't play another team twice.
       public override ToString() {
          return TeamA.ToString() + " vs. " + TeamB.ToString(); 
       }
    }
