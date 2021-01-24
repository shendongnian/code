           public class ViewModel : INotifyPropertyChanged
           {
            public ViewModel()
            {
                CreateTestData();
                AddSubjectCommand = new Command(AddSubject);
            }
    
            public ICommand AddSubjectCommand { get; }
    
            private ObservableCollection<Subject> _subjects;
            public ObservableCollection<Subject> Subjects
            {
                get => _subjects;
                set
                {
                    _subjects = value;
                    OnPropertyChanged();
                }
            }
    
            public void AddSubject()
            {
                Subjects = new ObservableCollection<Subject>();
                DataTable subjectsTable = new DataTable();
    
                foreach (Subject subject in subjects)
                {
                    //DataRow dataRow = subjectsTable.NewRow();
                    //dataRow[0] = subject.Name;
                    //dataRow[1] = subject.ClassesPerWeek;
                    //subjectsTable.Rows.Add(dataRow);
    
                    Subjects.Add(new Subject
                    {
                        Name = subject.Name,
                        ClassesPerWeek = subject.ClassesPerWeek
                    });
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            #region Test data
    
            public IList<Subject> subjects { get; set; }
            
            private void CreateTestData()
            {
                subjects = new List<Subject>();
                subjects.Add(new Subject { Name = "Subject 1", ClassesPerWeek = 5 });
                subjects.Add(new Subject { Name = "Subject 2", ClassesPerWeek = 10 });
            }
    
            #endregion
            }
