    private string id;
    public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                try
                {
                    this.id = value == null ? Guid.NewGuid().ToString("D") : value;
                }
                catch (Exception ex) {
                    throw ex;
                }
            }
        }
    }
