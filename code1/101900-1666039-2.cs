    partial void InsertBooking(Booking instance)
    {
        instance.LastModified = DateTime.Now;
        if (this.AuditUserID.HasValue)
        {
            instance.LastModifiedByID = this.AuditUserID;
        }
        this.ExecuteDynamicInsert(instance);
    }
    partial void UpdateBooking(Booking instance)
    {
        instance.LastModified = DateTime.Now;
        if (this.AuditUserID.HasValue)
        {
            instance.LastModifiedByID = this.AuditUserID;
        }
        this.ExecuteDynamicUpdate(instance);
    }
