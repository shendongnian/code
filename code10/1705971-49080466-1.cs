    public class Rarity
    {
        public Rarity(int numValue)
        {
            switch(numValue)
            {
                case 1:
                    StringValue = "Very Common";
                    break;
                case 2:
                    StringValue = "Common";
                    break;
                case 3:
                    StringValue = "Standard";
                    break;
                case 4:
                    StringValue = "Rare";
                    break;
                case 5:
                    StringValue = "Very Rare";
                    break;
                default:
                    StringValue = "";
                    break;
            }
        }
        public int NumValue { get; set; }
        public string StringValue { get; set; }
    }
