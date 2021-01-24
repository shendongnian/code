    public class UsingStuff : MonoBehaviour 
    {
        private void Start () {
            Player myPlayer = new Player(); //Makes an object called myPlayer
            Player otherPlayer = new Player(); //Another player object
            //For functions
            myPlayer.Attack(); //myPlayer will attack
            otherPlayer.Move(); //otherPlayer.move
            //For variables
            myPlayer.name = "Dave";
            otherPlayer.name = "Emma";
            //Now both our players have different names
        }
    }
