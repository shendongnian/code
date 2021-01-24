    public class Korpa
    {
        public int Id { get; set; }
        public int Id_korisnika { get; set; }
        [ForeignKey("Id_korisnika")]
        public Korisnik Korisnik { get; set; }
        public int Id_Artikla { get; set; }
        [ForeignKey("Id_Artikla")]
        public Artikal Artikal { get; set; }
    }
