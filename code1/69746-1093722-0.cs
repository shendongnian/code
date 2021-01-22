    string sTest1 = "abc\0\0def";
    string sTest2 = sTest1.Replace("\0", "");
    Console.WriteLine(sTest2);
    int iLocation = sTest1.IndexOf('\0');
    string sTest3 = "";
    if (iLocation >= 0)
    {
        sTest3 = sTest1.Substring(0, iLocation);
    }
    else
    {
        sTest3 = sTest1;
    }
    Console.WriteLine(sTest3);
    Console.ReadLine();
