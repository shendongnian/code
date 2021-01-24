    public class Part : BindableObject
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string BrandImage { get; set; }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        public string Article { get; set; }
        public string Mfg { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<Offer> Offers { get; set; }
    }
