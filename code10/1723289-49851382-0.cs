        // Create a new instance of the scope assignment.
        IResultObject assignment = sccmConnection.CreateInstance("SMS_SecuredCategoryMembership");
        // Configure the assignment
        assignment.Properties["CategoryID"].StringValue = scopeId; // CategoryID from SMS_SecuredCategory
        assignment.Properties["ObjectKey"].StringValue = objectKey; // PackageID
        assignment.Properties["ObjectTypeID"].IntegerValue = objectTypeId; // can get it from SMS_ObjectName with objectkey (probably fixed values)
        // Commit the assignment
        assignment.Put();
