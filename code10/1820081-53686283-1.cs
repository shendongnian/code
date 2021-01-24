    class FamilyVM : INotifyPropertyChanged
    {
        private ObservableCollection<Family> families = new ObservableCollection<Family>();
        public ObservableCollection<Family> Families
        {
            get { return families; }
            set { families = value; NotifyPropertyChanged(); }
        }
        public void Load()
        {
            ObservableCollection<Family> families = new ObservableCollection<Family>();
            families.Add(new Family { ID = 1, Name = "Amphibian" });
            families.Add(new Family { ID = 2, Name = "Viperidae" });
            families.Add(new Family { ID = 3, Name = "Aranae" });
            Families = families;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
