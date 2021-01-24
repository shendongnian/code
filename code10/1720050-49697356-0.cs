    static void update(Employee emp)
    {
        using(var context = new EmployeeCtx())
        {
            var currentRecord = context.<dbsetname>.First(p => p.id == emp.id);
            if (currentRecord == null)
                // Handle not found condition
            else 
            {
                currentRecord.name = emp.name;
                context.SaveChanges();
            }
        }
    }
