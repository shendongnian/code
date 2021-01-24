    public class MyDateTimeConverter : IsoDateTimeConverter
    {
        public MyDateTimeConverter()
        {
            base.DateTimeFormat = "dd-MM-yyyy";
        }
    }
