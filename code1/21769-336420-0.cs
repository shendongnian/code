    string s = string.Empty;
    using(StreamReader sr = new StreamReader("filename", Encoding.UTF8))
    {
      s = sr.ReadToEnd();
      sr.Close();
    }
