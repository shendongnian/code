    class MainWindowVm
    {
        public MainWindowVm()
        {
            PathParts = new ObservableCollection<PathPart>();
            Path = new ObservableCollection<StudentData>();
    
            var allStudents = new ObservableCollection<StudentData>(new[]
                                                     {
                                                         new StudentData() { Name = "Bob", TextColor = Colors.Aqua },
                                                         new StudentData() { Name = "Mary", TextColor = Colors.Red },
                                                         new StudentData() { Name = "Joe", TextColor = Colors.Blue },
                                                         new StudentData() { Name = "Dan", TextColor = Colors.Green },
                                                     });
    
            Path.CollectionChanged += (sender, e) => { UpdatePath(); };
    
            //This should would normally be part of a button command, or something else that triggers a change to the path.
            Path.Add(allStudents[1]);
            Path.Add(allStudents[2]);
            Path.Add(allStudents[0]);
        }
    
        private void UpdatePath()
        {
            PathParts.Clear();
            foreach (var student in Path)
            {
                PathParts.Add(new PathPart() { Text = student.Name, Color = student.TextColor });
                if (student != Path.Last())
                {
                    PathParts.Add(new PathPart() { Text = " | ", Color = Colors.Black });
                }
            }
        }
    
        public ObservableCollection<PathPart> PathParts { get; }
        public ObservableCollection<StudentData> Path { get; }
    }
    class PathPart
    {
        public string Text { get; set; }
        public Color Color { get; set; }
    }
    class StudentData
    {
        public string Name { get; set; }
        public Color TextColor { get; set; }
    }
