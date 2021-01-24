    public class BattleSystemScript : GameManagerRevamped
    {
        static public int CoinsRandom;
        public TextMeshProUGUI Coins;
        protected virtual void Start()
        {  
            CoinsRandom = Random.Range(30, 50);
            Coins.text = CoinsRandom.ToString();
        } 
    }
