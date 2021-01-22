    public IQueryable<E_Product> Product_GetList_ByChassisId(int chassisId) 
    { 
        return dc.E_Products 
            .Where(x => x.Deleted == false) 
            .Where(x => x.Published == true) 
            .Where(x => x.E_Product_Chassis 
                .Any(c => c.ChassisId == chassisId && c.Deleted == false)) 
            .OrderBy(x => x.E_Product_Chassis.Min(c => c.Zindex)); 
    }
