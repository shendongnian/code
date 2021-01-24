    public static Samples ReadCsv(StreamReader reader)
    {
        return ReadCSv(reader.ReadLine());
    }
    public static Samples ReadCsv(string line)
    {
        parts = line.Split(',');
        return new Samples() {
            Fenner = Convert.ToDouble(parts[0]),
            Abom = Convert.ToDouble(parts[1])
        };
    }
