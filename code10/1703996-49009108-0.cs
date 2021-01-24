    public partial class SomeEfModel
    {
        [Key]
        public int Id { get; set; }
        public DateTimePeriod Time { get; set; }
    }
    public class DateTimePeriod
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
