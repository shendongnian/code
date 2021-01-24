     public class Model
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public Adres Adress { get; set; }
    }
    public class Adres
    {
        public string Ulica { get; set; }
        public string Numer_domu { get; set; }
        public string Numer_mieszkania { get; set; }
    }
    ...
