    public class Player : MonoBehaviour {
        public string name;
        public int power;
        public int speed;
        public void gameData() {
            print ("Player name = " + name);
            print ("Player power = " + power);
            print ("Player speed = " + speed);   
        }
        private void Attack () { }
    }
    ...
    public class UsingStuff : MonoBehaviour {
    var P1 = new Player();
    var P2 = new Player();
    var P3 = new Player();
    private void Start () {
        P1.name  = "Bill";
        P1.power = 10;
        P1.speed = 30;
        P2.name  = "Bob";
        P2.power = 100;
        P2.speed = 3;
        P3.name  = "Jerry";
        P3.power = 50;
        P3.speed = 10;
        P1.gameData();
        P2.gameData();
        P3.gameData();
    }
