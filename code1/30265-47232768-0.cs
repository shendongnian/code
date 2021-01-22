    string number = "17463";
    int sum = 0;
    String singleDigit = "";
    for (int i = 0; i < number.Length; i++)
    {
    singleDigit = number.Substring(i, 1);
    sum = sum + int.Parse(singleDigit);
    }
    Console.WriteLine(sum);
    Console.ReadLine();
