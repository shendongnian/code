    public PayData PayData
    {
        get
        {
            if (_payData != null)
            {
                return this._payData;
            }
            else
            {
                var sourceJson = Aes.Decrypt(Data, AppKey);
                this._payData = JsonConvert.DeserializeObject<PayData>(sourceJson);
                return this._payData
            }
        }
        set { this._payData = value; }
    }
