    static string RemoveAccents (string input)
    {
        string normalized = input.Normalize(NormalizationForm.FormKD);
        Encoding removal = Encoding.GetEncoding(Encoding.ASCII.CodePage,
                                                new EncoderReplacementFallback(""),
                                                new DecoderReplacementFallback(""));
        byte[] bytes = removal.GetBytes(normalized);
        return Encoding.ASCII.GetString(bytes);
    }
