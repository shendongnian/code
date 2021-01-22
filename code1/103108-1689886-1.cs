    public MyObject MyProperty
    {
        get
        {
            if (this.myField == null)
            {
                this.myField = new MyObject();
            }
            return this.myField;
        }
    }
