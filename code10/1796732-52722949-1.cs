    public float LoadCoinsAmount()
    {
        return PlayerPrefs.GetFloat("COINS");
    }
    public void SaveCoinsAmount(float coins)
    {
        PlayerPrefs.SetFloat("COINS", coins);
    }
