    public class Korpa
    {
        public int Id { get; set; }
        public int Id_korisnika { get; set; }
        public Korisnik Korisnik { get; set; }
        public int Id_Artikla { get; set; }
        public Artikal Artikal { get; set; }
        public int Artikal_Id {get; set;} // Add this property
    
    }
