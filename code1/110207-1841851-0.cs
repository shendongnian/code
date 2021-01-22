    public class IndkøbsKurvReservedele
    {
        //public Reservedele Reservedel  { get; private set;}
        private int Rnr;
        public string Navn { get; private set; }
        public double Pris { get; private set; }
        public string Type { get; private set; }
        public int Antal { get; private set; }
        public double SPris { get; private set; }
        public IndkøbsKurvReservedele(Reservedele reservedel, int antal, double sPris)
        {
            Rnr = reservedel.Rnr;
            Navn = reservedel.Navn;
            Pris = reservedel.Pris;
            Type = reservedel.Type;
            Antal = antal;
            SPris = sPris;
        }
        public int HenrReservedelsNummer()
        {
            return Rnr;
        }
    }
