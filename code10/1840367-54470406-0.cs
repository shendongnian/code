    public bool Equals2(in Object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            EvilClass p = (EvilClass)obj;
            p.x = 42;
            return (x == p.x);
        }
    }
