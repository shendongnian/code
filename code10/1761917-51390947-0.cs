    class RackOfBeverages
    {
        public string Label { get; }
        public int Count { get; private set; }
        public RackOfBeverages(string label, int initialCount)
        {
            Label = label;
            Count = initialCount;
        }
        public void Restock(int howMany)
        {
            Count += howMany;
        }
        public bool Dispense()
        {
            if (Count > 0)
            {
                --Count;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
