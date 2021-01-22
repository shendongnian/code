    var s = "%5d%96%b6%f6%84%5e%ea%da%c5%15%c4%0e%403h%b9Ui4h";
    var ms = new MemoryStream();
    for (var i = 0; i < s.Length; i++)
    {
        if (s[i] == '%')
        {
            ms.WriteByte(
                byte.Parse(s.Substring(i + 1, 2), NumberStyles.AllowHexSpecifier));
            i += 2;
        }
        else if (s[i] < 128)
        {
            ms.WriteByte((byte)s[i]);
        }
    }
    byte[] infoHash = ms.ToArray();
    string temp = BitConverter.ToString(infoHash);
    // "5D-96-B6-F6-84-5E-EA-DA-C5-15-C4-0E-40-33-68-B9-55-69-34-68"
