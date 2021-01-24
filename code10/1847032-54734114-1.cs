    public class PlayerValues : BattleSystemScript
    {
        int CoinsRandomValue;
        public TextMeshProUGUI PlayerCoins;         
        protected override void Start()
        {
            // call to the parent Start
            base.Start();
            CoinsRandomValue += CoinsRandom;
            PlayerCoins.text = CoinsRandomValue.ToString();
        }
    }
