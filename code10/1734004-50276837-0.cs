    public class Player
    {
        private int? total; // <- Nullable<int> here
        public int Total
        {
            get
            {
                if(total.HasValue) // <- If value is set return that value.
                {
                    return total.Value;
                }
                total = 0;
                foreach (int card in hand)
                {
                    total += card;
                }
                return total;
            }
            set { this.total = value; }
        }
    }
