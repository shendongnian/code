    public MyObject MyProperty
    {
        get
        {
            return this.myField ?? (this.myField = new MyObject());
        }
    }
