    public class Klient 
    {
        private static int KlientID = 1;
        public string numer { get; set; }
    
        public string numerklienta { get; set; }
        public string nazwisko { get; set; }
    
        public ObservableCollection<Biezace> rory = new ObservableCollection<Biezace>();
        public ObservableCollection<Lokata> lokaty = new ObservableCollection<Lokata>();
        public ObservableCollection<Debet> debety = new ObservableCollection<Debet>();
