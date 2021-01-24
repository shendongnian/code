    private async Task RefreshList()
    {
       using (this._dialogs.Loading("Loading..."))
       {
           try
           {
               var task = await this._classService.GetClasses();
           }
           catch(Exception exc)
           {
               // This is done only for debugging to check if here lies the problem
               throw exc;
           }
       }
    }
