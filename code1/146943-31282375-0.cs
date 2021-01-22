    public class Candy
    {
        public ICandySettings CandySettings { get; private set; }
    
        ...
    
        public Candy(ICandySettings candySettings)
        {
            this.CandySettings = candySettings;
            this.CandySettings.GetSetting("box"); 
        }
    }
