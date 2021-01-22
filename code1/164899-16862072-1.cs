        public string DisplayNDecimal(double dbValue, int nDecimal)
        {
            StringBuilder decimalPoints = new StringBuilder("0");
            if (nDecimal > 0)
            {
                decimalPoints.Append(".");
                for (int i = 0; i < nDecimal; i++)
                    decimalPoints.Append("0");
            }
            return dbValue.ToString(decimalPoints.ToString());
        }
