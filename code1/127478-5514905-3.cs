    public Encoding ContentEncoding
    {
        get
        {
            if (!this._flags[0x20] || (this._encoding == null))
            {
                this._encoding = this.GetEncodingFromHeaders();
                if (this._encoding == null)
                {
                    GlobalizationSection globalization = RuntimeConfig.GetLKGConfig(this._context).Globalization;
                    this._encoding = globalization.RequestEncoding;
                }
                this._flags.Set(0x20);
            }
            return this._encoding;
        }
        set
        {
            this._encoding = value;
            this._flags.Set(0x20);
        }
    }
