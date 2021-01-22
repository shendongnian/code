    public class MainWindow_ViewModel : INotifyPropertyChanged
    {
        public MainWindow_ViewModel()
        {
            this.Cars = LoadInitialCarList();
            this.SelectedCar = this.Cars.First();
        }
        public List<Car> Cars
        {
            get { return cars; }
            set
            {
                if (cars != value)
                {
                    cars = value;
                    OnPropertyChanged("Cars");
                }
            }
        }
        private List<Car> cars;
        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if (selectedCar != value)
                {
                    selectedCar = value;
                    OnPropertyChanged("SelectedCar");
                }
            }
        }
        private Car selectedCar;
        private List<Car> LoadInitialCarList()
        {
            List<Car> list = new List<Car>();
            list.Add(new Car("Chevrolet", "Camaro", 1968));
            list.Add(new Car("Ford", "Mustang", 1965));
            list.Add(new Car("Pontiac", "GTO", 1970));
            return list;
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
