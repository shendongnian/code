    public void ByRef(ref Rect entity)
    {
       if (entity.Y + entity.Height > 800)
       {
          entity.Y++;
       }
    }
    
    public Rect ByImutableReturn(Rect entity)
    {
       return entity.Y + entity.Height > 800 ? new Rect(entity.Height, entity.Y + 1) : entity;
    }
    
    public Rect ByReturn(Rect entity)
    {
       if (entity.Y + entity.Height > 800)
       {
          entity.Y++;
       }
    
       return entity;
    }
