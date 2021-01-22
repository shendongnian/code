    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        if (obj.GetType() != GetType())
        {
            return false;
        }
        var entity = (Entity)obj;
        if ((Id == Guid.Empty) || (entity.Id == Guid.Empty))
        {
          return false;
        }
        return (entity.Id == Id);
    }
