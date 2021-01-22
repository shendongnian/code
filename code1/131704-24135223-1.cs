    public string propcheckSum
    {
        get {
            libfuncs objLib = new libfuncs();
            string strCheckSum = objLib.getchecksum("YourMerchantID", Session["ClientID"].ToString(), strAmount, "UrReturnUrl", "your working key");
            return strCheckSum;
        }
    }
