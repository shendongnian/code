    var obj2detail = obj2.HomeSection2Detail.Where(w => w.ID == detail.ID).FirstOrDefault();
    if (obj2detail != null)
    {
        // this line of code only delete the relationship.
        obj2.HomeSection2Detail.Remove(obj2detail);
    
        // If you want to delete the entity you need the DbContext help 
        // and your HomeSection2Details DbSet<HomeSection2Detail> like below
        yourDbContext.HomeSection2Details.Remove(student);
    }
