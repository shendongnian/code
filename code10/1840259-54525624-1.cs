    public class TaxPayer : ObservableObject
    {
        public TaxPayer(House house)
        {
            House = house;
        }
        [DependsOn("House.Safe.Value")]
        public string TaxCode => House.Safe.Value;
        private House house;
        public House House
        {
            get => house;
            set => SetField(ref house, value);
        }
    }
    public class House : ObservableObject
    {
        public House(Safe safe)
        {
            Safe = safe;
        }
        private Safe safe;
        public Safe Safe
        {
            get => safe;
            set => SetField(ref safe, value);
        }
    }
    public class Safe : ObservableObject
    {
        private string val;
        public string Value
        {
            get => val;
            set => SetField(ref val, value);
        }
    }
