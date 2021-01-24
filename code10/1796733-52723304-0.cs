    public long LoadCoinsAmount()
    {
        string coinString = PlayerPrefs.GetString("COINS");
        if (long.TryParse(coinString, out long result))
        {
            return result;
        }
    
        return 0;
    }
    
    public void SaveCoinsAmount(long coins)
    {
        PlayerPrefs.SetString("COINS", coins.ToString());
    }
