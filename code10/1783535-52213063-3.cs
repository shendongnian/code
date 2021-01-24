    public static void Order (Data data, string number)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));
        if (string.IsNullOrEmpty(number)) number = "4a";
        // Do stuff here
    }
