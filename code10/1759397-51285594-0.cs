    string errorneousString = "ÇËÅÊÔÑÏÖÏÑÇÓÇ ÁÉÌÏÓÖÁÉÑÉÍÇÓ";
    byte[] asIso88591Bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(errorneousString);
    string asGreekString = Encoding.GetEncoding("windows-1253").GetString(asIso88591Bytes);
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.WriteLine(asGreekString);
