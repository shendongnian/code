    string input = "USD 2.4700/Tgt sh.";
    var numbers = Regex.Matches(input, @"[\d]+\.?[\d]*");
    foreach (Match res in numbers)
    {
        if (!string.IsNullOrEmpty(res.Value))
        {
            decimal i = decimal.Parse(res.Value);
            Console.WriteLine("Number: {0}", i);
        }
    }
