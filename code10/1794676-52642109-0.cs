    public string Id
    {
        get
        {
            return this.Id;
        }
        set
        {
            try
            {
                this.Id = value ?? Guid.NewGuid().ToString("D");
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
