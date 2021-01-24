        private async void DoATask()
        {
           progressBar.Visibility=ViewStates.Visible; 
           await UpdateInterface();
           progressBar.Visibility=ViewStates.Gone; 
        }
    **Note:** `UpdateInterface()` method should be a System.Threading.Tasks.Task and not a Void for this to work because void cannot have a definition for awaiter to it. 
