    MD5 m = MD5.Create();
    byte[] hash = m.ComputeHash(System.Text.Encoding.ASCII.GetBytes("23"));
    Ascii85 encoder = new Ascii85();
    encoder.EnforceMarks = false;
    string hash85 = encoder.Encode(hash);
    Console.Out.WriteLine(hash85);
