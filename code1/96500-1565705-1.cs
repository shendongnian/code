    public int GetHashCode(IPathwayModule obj)
    {
        unchecked {
            int h = obj.Block + obj.Module.ModeleId.GetHashCode() + (int) obj.Status;
            if (obj.class != null)
               h += obj.Class.ClassId.GetHashCode();
            return h;
        }
    }
