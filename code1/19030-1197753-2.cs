    // normal form code.
    private void Save()
    {
        // you can do stuff before and after. normal scoping rules apply
        saveControl.InvokeSave(
            delegate
            {
                // everywhere the save control is used, this code is different
                // but the class of errors and the stage we are catching them at
                // is the same
                DataContext.SomeStoredProcedure();
                DataContext.SomeOtherStoredProcedure();
                DataContext.SubmitChanges();
            });
    }
