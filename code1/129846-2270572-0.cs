    using (var context = new DefaultDataContext())
    {
        var defects = context.Defects.Where(d => d.Status==Status.Open);             
        
        foreach(Defect d in defects)
        {
            defect.Status = Status.Fixed;                     
            defect.LastModified = DateTime.Now;
        }
        context.SubmitChanges();                 
    }
