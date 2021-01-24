    string result;
    using (var reader = new StreamReader(await response.Content.ReadAsStreamAsync()))
    {
        char[] chars = new char[maxAllowedLimit];
        int read = reader.ReadBlock(chars, 0, chars.Length);
        result = new string(chars, 0, read);
    }
