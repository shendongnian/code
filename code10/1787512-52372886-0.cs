    public class EventFilesViewModel : INotifyPropertyChanged
    {
       public ObservableCollection<EventFiles> EventFiles { get; } = new ObservableCollection<EventFiles>();
    
       private string[] _filesList;
    
       //This would be my Update function, based on the ComboBox selection I would show some files in my ListBox, but it's not
       public void GetFiles(string ptr)
       {
          _filesList = Directory.GetFiles(@"\\mp-2624/c$/xampp/htdocs/desenv2/public/esocial/eventos/aguardando/");
          EventFiles.Clear();
          foreach (string file in _filesList)
          {
             var r = new Regex(ptr, RegexOptions.IgnoreCase);
             var tempFiles = new EventFiles { Key = file, Value = file.Split('/')[9] };
             if (r.Match(file).Success)
             {
                EventFiles.Add(tempFiles);
             }
          }
          OnPropertyChanged(nameof(EventFilesViewModel));
       }
    
       public event PropertyChangedEventHandler PropertyChanged;
    
       [NotifyPropertyChangedInvocator]
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }
    }
