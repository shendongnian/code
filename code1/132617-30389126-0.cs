    I hope this helps try to convert the whole string into particular case either lower case or Upper case and use the Lowercase string for comparsion
       public string ConvertMeasurements(string unitType, string value)
        {
            switch (unitType.ToLower())
            {
                case "mmol/l": return (Double.Parse(value) * 0.0555).ToString();
                case "mg/dl": return (double.Parse(value) * 18.0182).ToString();
            }
        }
