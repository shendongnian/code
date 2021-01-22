    public int DeleteDepartment(Guid departmentUUID)
    {
        int returnValue = 0;
        Department holder = new Department();
        holder.DepartmentUUID = departmentUUID; // DepartmentUUID is the primary key of this object (entity in the db)
        using (MyContectObject context = new MyContectObject())
        {
            context.AttachTo("Departments", holder);
            context.DeleteObject(holder);
            int numOfObjectsAffected = context.SaveChanges();
            returnValue = numOfObjectsAffected;
            context.Dispose();
        }
        return returnValue;
    }
