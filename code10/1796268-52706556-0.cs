    public static async void ProcessSinglePart(string PartPathToRead, string PartPathToSave)
    {
        // DO SOME STUFF BEFORE THE CHECK
        clickWaitTask = new TaskCompletionSource<bool>();
        if (PartLength < PartWidth) // SOME CHECK VALUES
        {
             await clickWaitTask.Task;
        }
        //DO SOME STUFF AFTER THE CHECK
    }
