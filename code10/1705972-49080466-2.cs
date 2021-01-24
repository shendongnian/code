    public class Rarity
    {
        public Rarity(int numValue)
        {
            NumValue = numValue;
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
        public int NumValue { get; }
        public string StringValue { get; }
    }
