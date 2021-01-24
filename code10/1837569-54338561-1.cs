    // Simplify the if..else block
    request.ManagedCare = request.GovernmentEnrollment;
    request.GovernmentEnrollment = !request.GovernmentEnrollment;
    // Notifying the context that the 'request' entity has been modified.
    // EntityState enum is under System.Data.Entity namespace
    moadEntities.Entry(request).State = EntityState.Modified;
    // Now we can save the changes.
    moadEntities.SaveChanges();
