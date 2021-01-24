        // Find the existing scope assignement that matches our parameters.
        IResultObject assignment = sccmConnection.GetInstance("SMS_SecuredCategoryMembership.CategoryID='" + scopeId + "',ObjectKey='" + objectKey + "',ObjectTypeID=" + objectTypeId.ToString());
        // Make sure we found the scope.
        if(assignment == null)
            throw new Exception("Unable to find matching scope, object, and object type.");
        else
            assignment.Delete();
