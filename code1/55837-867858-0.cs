    try
    {
        using (TransactionScope scope = new TransactionScope())
        {
            //Do some stuff
            //Submit changes, use ConflictMode to specify what to do
            context.SubmitChanges(ConflictMode.ContinueOnConflict);
        
            scope.Complete();
        }
    }
    catch (ChangeConflictException cce)
    {
            //Exception, as the scope was not completed it will rollback
    }
