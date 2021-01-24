    public PayData PayData
    {
        get
        {
            if (_payData == null)
            {
                var sourceJson = Aes.Decrypt(Data, AppKey);
                this._payData = JsonConvert.DeserializeObject<PayData> (sourceJson);//<---store it
            }
            return this._payData;
        }
        set { this._payData = value; }
    }
