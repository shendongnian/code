        public void InitializeOrIncrement(decimal value)
        {
            // if Total is null then initialize, otherwise increment
            Total = (Total == null) ? value : Total + value;
        }
        public decimal? Total { get; set; }
