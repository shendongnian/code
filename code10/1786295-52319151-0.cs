    public void SetName(string name)
    {
        if (name == null)
            throw new Exception("The name can't be blank");
        else
            this.Name = name;
    }
