    public string Item1 {get;set;}
    public int Item2 {get;set;}
    public override bool Equals(object obj)
    {
        var item = obj as ObjDTO;
        if (item == null)
        {
            return false;
        }
        return this.Item1 == item.Item1 && this.Item2 == item.Item2;
    }
    public override int GetHashCode()
    {
        if (this.Item1 == null && this.Item2 == 0)
        {
            return base.GetHashCode();
        }
        return this.Item1.GetHashCode() + this.Item2.GetHashCode();
    }
