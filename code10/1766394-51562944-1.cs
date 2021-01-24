    class NAWGegeven
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Geslacht { get; set; }
        public string Adres { get; set; }
        public int Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
        public DateTime Geboortedatum { get; set; }
    
        public override string ToString()
        {
            //your formatted output string here
            //Example
            return $"{nameof(Voornam)}: {Voornam}, {nameof(Achternaam)}: {Achternaam}";
        }
    
    }
