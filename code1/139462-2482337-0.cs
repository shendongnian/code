    string name = "Århus.txt";
    string kd = name.Normalize(NormalizationForm.FormKD);
    byte[] kd_bytes = Encoding.Unicode.GetBytes(kd);
    byte[] ascii_bytes = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, kd_bytes);
    string flattened = Encoding.ASCII.GetString(ascii_bytes);
