    public class ClassName
    {
        private const format = "yyyyMMdd" //for example
        [NotMapped]
        public DateTime Date {
           get {
                 DateTime.Parse(Date, format, CultureInfo.InvariantCulture);
               }
           set {
                 Date = value.ToString(format);
               }
         }
         [column("Date")]
         public string StringDate { get; set; }
    }
