    public string ByteArrayToStr(byte [] dBytes)
    {
    System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
    return enc.GetString(dBytes);
    }
