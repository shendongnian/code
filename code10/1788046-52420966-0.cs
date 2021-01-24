    public sealed class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {
            DateFormatString = "yyyy-MM-dd";
            // ... other formatting stuff ...
        }
    }
