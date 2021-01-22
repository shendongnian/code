    public class TaxCheatsFormViewModel
    {
        private List<Country> countries { get; set; }
    
        public TaxCheat Cheat { get; private set; }
        public SelectList CountryOfBirth { get; private set; }
        public SelectList CountryOfResidence { get; private set; }
        public SelectList CountryOfDomicile { get; private set; }
    
        public TaxCheatsFormViewModel(TaxCheat baddie)
        {
            TaxCheat = baddie;
            countries = TaxCheatRepository.GetList<Country>();
            CountryOfBirth = new SelectList(countries, baddie.COB);
            CountryOfResidence = new SelectList(countries, baddie.COR);
            CountryOfDomicile = new SelectList(countries, baddie.COD);
        }
    }
