    string textBuff = "-1.123    4.234  34.12  126.4  99      22";
    double[] result = textBuff
        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(s => double.Parse(s))
        .ToArray();
    double x = result[0];
    //    ...
    double k = result[5];
