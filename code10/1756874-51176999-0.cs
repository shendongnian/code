    [TestMethod]
    public void GetAndSetValue()
    {
        GetAndSetValue(false);
    
        void GetAndSetValue(bool toggle)
        {
            // details not important
            if (!toggle)
                GetAndSetValue(true);
        }
    }
