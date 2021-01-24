    int sum = SumOfDegreesString(beta.Text, gamma.Text);
    private static double SumOfDegreesString(string s1, string s2) {
        double a = 0, b = 0;
        double.TryParse(s1.Replace("°", ""), out a);
        double.TryParse(s2.Replace("°", ""), out b);
        return a + b;
    }
