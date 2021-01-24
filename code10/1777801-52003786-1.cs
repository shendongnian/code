    public class ViewModel 
    {
    
        public ViewModel()
        {
            Tree = new ObservableCollection<TreeViewModel>();
            LoadData();
        }
    
        private void LoadData()
        {
            var list1 = new PatientsList();
            list1.Patients.Add(new Patient { ID = 44, Name = "Ben Garsia", Year = 1985 });
            list1.Patients.Add(new Patient { ID = 22, Name = "Melisa Mayer", Year = 1968 });
            list1.Patients.Add(new Patient { ID = 33, Name = "Morgan Smith", Year = 1979 });
    
            var root = new TreeViewModel();
            root.Add(list1);
            Tree.Add(root);
        }
    
        public ObservableCollection<TreeViewModel> Tree { get; set; }
    }
