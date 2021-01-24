        public string ConditionalComma(int recordCount, int i)
        {
            if (i != recordCount - 1)
            {
                return ",";
            }
            return string.Empty;
        }
