    public static double GetDouble(string key)
    {
        var retrieveBytes = new byte[8];
        Array.Copy(BitConverter.GetBytes(PlayerPrefs.GetInt(key+"_doubleLowBits")), retrieveBytes, 4);
        Array.Copy(BitConverter.GetBytes(PlayerPrefs.GetInt(key+"_doubleHighBits")), 0, retrieveBytes, 4, 4);
        return BitConverter.ToDouble(retrieveBytes, 0);
    }
    public static void SetDouble(string key, double defaultValue)
    {
        var storeBytes = BitConverter.GetBytes(defaultValue);
        var storeIntLow = BitConverter.ToInt32(storeBytes, 0);
        var storeIntHigh = BitConverter.ToInt32(storeBytes, 4);
        PlayerPrefs.SetInt(key+"_doubleLowBits", storeIntLow);
        PlayerPrefs.SetInt(key+"_doubleHighBits", storeIntHigh);
    }
