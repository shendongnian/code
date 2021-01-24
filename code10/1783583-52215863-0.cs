      private async void SearchName(string name)
        {
            ResultDisplayGrid.IsBusy = true;
        
                try{
                    await GetStudentResults();
                }
                finally{
                    ResultDisplayGrid.IsBusy = false;
                }
        }
