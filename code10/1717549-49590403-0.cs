    int sum = SumOfDegreesString(beta.Text, gamma.Text);
    private static double SumOfDegreesString(string s1, string s2) {
        double a, b;
        if (double.TryParse(s1.Replace("°", ""), out a) && double.TryParse(s2.Text.Replace("°", ""), out b))
        {
            return a + b;
        }
        return 0;
    }
