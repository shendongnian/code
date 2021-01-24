    public class TreeViewModel
    {
        public TreeViewModel()
        {
            Children = new ObservableCollection<TreeViewModel>();
            Title = "Patients"; // Root node name
        }
    
        public string Title { get; private set; }
    
        public ObservableCollection<TreeViewModel> Children { get; }
    
        public void Add(PatientsList list)
        {
            foreach (var i in list.Patients)
            {
                var child = new TreeViewModel();
                child.Title = "Patient"; // Level2 node name
                child.Add(i);
                Children.Add(child);
            }
    
        }
    
        private void Add(Patient patient)
        {
            Add($"ID: {patient.ID}");
            Add($"Name: {patient.Name}");
            Add($"Year: {patient.Year}");
        }
    
        private void Add(string title)
        {
            Children.Add(new TreeViewModel { Title = title });
        }
    }
