    public partial class SomeEfModelDto
    {
        public int Id { get; set; }
        public DateTimePeriodDto Time { get; set; }
        public SomeEfModelDto(SomeEfModel model)
        {
            Id = model.Id;
            Time = new DateTimePeriodDto(model.DateTimePeriod);
        }
    }
