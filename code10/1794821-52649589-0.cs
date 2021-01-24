    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Linq;
    namespace WpfApp1
    {
        public class EmployeeModel
        {
            public string Name { get; set; }
        }
        public class EmployeeViewModel : ViewModelBase
        {
            readonly EmployeeModel model;
            string editName;
            public EmployeeViewModel (EmployeeModel model)
            {
                this.model = model;
                editName = Name;
                SaveChanges = new RelayCommand (() => { Name = EditName; SaveChanges.RaiseCanExecuteChanged (); }, () => IsDirty);
            }
            public string Name
            {
                get => model.Name;
                set
                {
                    model.Name = value;
                    RaisePropertyChanged (nameof (Name));
                }
            }
            public string EditName
            {
                get => editName;
                set
                {
                    editName = value;
                    RaisePropertyChanged (nameof (EditName));
                    SaveChanges.RaiseCanExecuteChanged ();
                }
            }
            public bool IsDirty => editName != Name;
            public RelayCommand SaveChanges { get; }
        }
        public class WindowViewModel
        {
            List<EmployeeModel> models = new List<EmployeeModel>
            {
                new EmployeeModel () { Name = "Janusz" },
                new EmployeeModel () { Name = "Grażyna" },
                new EmployeeModel () { Name = "John" },
            };
            public WindowViewModel ()
            {
                EmployeeViews = models.Select (x => new EmployeeViewModel (x)).ToList ();
            }
            public IEnumerable<EmployeeViewModel> EmployeeViews { get; }
            public EmployeeViewModel SelectedEmployeeView { get; set; }
        }
    }
