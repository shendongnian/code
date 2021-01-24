    class SelectedSchoolList : INotifyPropertyChanged
    {
       private string _schoolName;
       private string _score;
    
       public string SchoolName 
       { 
           get => _schoolName; 
           set { _schoolName = value; NotifyPropertyChanged();}
       }
       public string Score 
       { 
           get => _score; 
           set { _score = value; NotifyPropertyChanged();}
       }
       public ObservableCollection<SelectedStudentList> SelectedStudentArray{ get; set;}
       public event PropertyChangedEventHandler PropertyChanged;
       private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
       {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }
     }
