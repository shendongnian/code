    public void Parse(StringSteamReader r) {
        double x = r.ReadDouble();
        int y = r.ReadInt();
        string z = r.ReadWord();
        double[] arr = r.ReadDoubleArray();
        MyParsableObject o = r.ReadObject<MyParsableObject>();
        MyParsableObject [] oarr = r.ReadObjectArray<MyParsableObject>();
    }
