    public override int GetHashCode(SheetRow obj)
    {
        return ((obj.ColDescriptionOne.GetHashCode()*397) 
               + (obj.ColDescriptionSecond.GetHashCode()*397));
    }
