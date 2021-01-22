    int[] source1 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    string txt1 = source1.ToDelimitedString(x => x.ToString(), "|");
    Console.WriteLine(txt1);    // "1|2|3|4|5|6|7|8|9|10"
    int[] dest1 = txt1.FromDelimitedString(x => int.Parse(x), "|").ToArray();
    Console.WriteLine(source1.SequenceEqual(dest1));    // "True"
    // ...
    string[] source2 = new[] { "Fish & Chips", "Salt & Pepper", "Gin & Tonic" };
    string txt2 = source2.ToDelimitedString(x => HttpUtility.UrlEncode(x), "&");
    Console.WriteLine(txt2);    // "Fish+%26+Chips&Salt+%26+Pepper&Gin+%26+Tonic"
    var dest2 = txt2.FromDelimitedString(x => HttpUtility.UrlDecode(x), "&");
    Console.WriteLine(source2.SequenceEqual(dest2));    // "True"
