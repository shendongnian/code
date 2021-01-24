    public static void MarkAsCompleted(Steps step)
    {
        using (var context = new ApplicationDbContext())
        {
            step = context.Steps.Find(step.id); //use the retrieved instance
            step.Completed = true;
    
            context.SaveChanges();
        }
    } 
