    public class PersonePM
    {
        [Key]
        public Guid Id { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Sesso { get; set; }
        public string StringaCognomeNome { get; set; }
        public DateTime DataNascita { get; set; }
        public string LuogoNascita { get; set; }
        /*Use the Getter to set the property based on other fields*/
        public string StringaNascita 
        {
            get
            {
                return LuogoNascita +
                    (DataNascita != DateTime.MinValue ?
                         (((DataNascita.Day == 1) || (DataNascita.Day == 8) || (DataNascita.Day == 11)) ? " l'" : " il ") +
                         string.Format("{0:d MMMM yyyy}", DataNascita) : string.Empty);
            }
        }
        /* END of solution */
        public string CodiceFiscale { get; set; }
    }
    public IEnumerable<PersonePM> GetPersoneByCognome(string cognome)
        {
            return
                (from p in ObjectContext.Persone
                 where p.Cognome.ToLower().Contains(cognome.Trim().ToLower())
                 select new PersonePM
                 {
                     Id = p.ID,
                     Cognome = p.Cognome,
                     Nome = p.Nome,
                     Sesso = p.IsMaschio == true ? "M" : "F",
                     StringaCognomeNome = p.Cognome + " " + p.Nome,
                     DataNascita = p.DataNascita.HasValue ? p.DataNascita.Value : DateTime.MinValue,
                     LuogoNascita = (p.IsMaschio == true ? "Nato a " : "Nata a ") + p.Citta.Denominazione + " (" + p.Citta.Provincia.Trim() + ")",
                     CodiceFiscale = p.CodiceFiscale,
                 });
        }
