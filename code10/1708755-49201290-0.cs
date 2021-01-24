    private IMvxAsynCommand _classroomSelectedCommand;
    public IMvxAsynCommand ClassroomSelectedCommand =>  _classroomSelectedCommand ?? (_classroomSelectedCommand = new MvxAsyncCommand<ClassroomViewModel>(ClassroomSelectedAsync));
    
    private async Task ClassroomSelectedAsync(Model obj)
    {
       using (UserDialogs.Instance.Loading("Loading..."))
       {
           await Task.Delay(300);
           try
           {
               ShowViewModel<ClassroomViewModel>(new { Id = obj.Id });
           }
           catch (Exception ex)
           {
    
           }
        }
     }
