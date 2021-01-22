    string s = "9quali52ty3";
    byte[] ASCIIValues = Encoding.ASCII.GetBytes(s);
    foreach(byte b in ASCIIValues) {
        Console.WriteLine(b);
    }
