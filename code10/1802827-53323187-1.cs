     private async Task LoadAllDataAsync()
        {
            AllBases.Clear();
            try
            {
                using (var UOW = _UnitOfWorkFactory.Create())
                {
                    foreach (Base ba in await Task.Run(() => _BaseRepository.GetAll()))
                    {
                        AllBases.Add(ba);
                    }
                }
            }
            catch (Exception)
            {
                await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => {
                    Messenger.Default.Send(new ToastErrorMessage { Message = "Error: There was a problem with loading the data" });
                }));
            }     
        }
