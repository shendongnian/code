    class GramToAppropriateUnitPrefixConverter : IValueConverter
    {
        private List<string> unitsPrefix = new List<string>() //unit prefixes scalings by *10^3 in order, where the middle value is = *10^0
        {
            "G",
            "M",
            "k",
            "",
            "m",
            "μ",
            "n"
        };
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is double number)
            {
                string numAsString;
                int sigFigs = 3;
                string unit = "g";
                int noPrefixIndex = (unitsPrefix.Count / 2);
                int unitsPrefixIndex = noPrefixIndex;
                numAsString = number.ToString("G" + sigFigs.ToString()).Replace("+", ""); //Convert to $sigFigs number of significant figures
                string[] numberStandForm = numAsString.Split('E'); //Convert to standard form (number = [0] * 10^[1])
                if (numberStandForm.Count() == 2)
                {
                    unitsPrefixIndex = noPrefixIndex +(int.Parse(numberStandForm[1]) / 3);
                    //Check the index is not out the range of the list
                    if (unitsPrefixIndex < 0)
                        unitsPrefixIndex = 0;
                    else if (unitsPrefixIndex > unitsPrefix.Count - 1)
                        unitsPrefixIndex = unitsPrefix.Count - 1;
                    //Change the standard form number so it is in the form ->   number * 10^(multipul of 3)
                    var power = int.Parse(numberStandForm[1]) + ((unitsPrefixIndex - noPrefixIndex) * 3);
                    string numberStr = (double.Parse(numberStandForm[0]) * Math.Pow(10, power)).ToString();
                }
                numAsString = numberStandForm[0] + unitsPrefix[unitsPrefixIndex] + unit;
                return numAsString;
            }
            return Binding.DoNothing;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
