    public class myParent 
    {
        [Key]
        public int Id { get; set; }
        // navigation properties
        public int VatNumber { get; set; }
        private virtual Addresse FrenchAddress { get; set; }
        private virtual Addresse DutchAddress { get; set; }
 
        public Addresse CompanyAddress {
            get {
                 switch (System.Globalization.CultureInfo.Name)
                 {
                     case "fr-CA": //Canadian French
                     case "fr-FR": //France French
                         return FrenchAddress;
                     case "nl-NL": //Netherlands Dutch
                         return DutchAddress;
                     default:
                         throw new NotImplementedException();
                }
                set;
            }
        }
    }
