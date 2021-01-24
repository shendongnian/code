    // Convert utf-8 bytes to a string.
    s_unicode2 = System.Text.Encoding.UTF8.GetString(apduRsp.Data);
    List<string> test = new List<string>();
    if (s_unicode2.Length > 0)
    {
       test = GetWords(s_unicode2);
    }
