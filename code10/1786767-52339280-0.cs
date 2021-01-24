    class ReturnObjectA
    {
        [JsonProperty(ItemConverterType = typeof(CustomDateTimeConverter))]
        public DateTime[] ReturnDate { get; set; }
    }
