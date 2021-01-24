    [TestMethod]
    public void GetAndSetValue()
    {
        GetAndSetValue(false);
    }
    private void GetAndSetValue(bool toggle)
    {
        // details not important
        if (!toggle)
            GetAndSetValue(true);
    }
