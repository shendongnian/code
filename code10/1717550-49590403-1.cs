    private static double SumOfDegreesString(string s1, string s2) {
        if (double.TryParse(s1.Replace("°", ""), out double a) && double.TryParse(s2.Text.Replace("°", ""), out double b))
        {
            return a + b;
        }
        return 0;
    }
