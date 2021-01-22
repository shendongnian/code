    public int GetHashCode(IPathwayModule obj)
    {
        unchecked {
            int h = obj.Block + obj.Module.ModeleId.GetHashCode() + (int) obj.Status;
        }
        int h;
        if (obj.Class != null)
        {
            h = obj.Block.GetHashCode() + obj.Module.ModuleId.GetHashCode() + obj.Status.GetHashCode() + obj.Class.ClassId.GetHashCode();
        }
        else
        {
            h = obj.Block.GetHashCode() + obj.Module.ModuleId.GetHashCode() + obj.Status.GetHashCode() + "NOCLASS".GetHashCode();
        }
        return h;
    }
