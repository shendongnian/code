    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _firstName;
        public string FirstName
        {
            get { return this._firstName; }
            set
            {
                this._firstName = value;
                this.PropertyChanged.Notify(()=>this.FirstName);
            }
        }
    }
     
    private void firstName_PropertyChanged(Employee sender)
    {
        Console.WriteLine(sender.FirstName);
    }
    employee = new Employee();
    employee.SubscribeToChange(() => employee.FirstName, firstName_PropertyChanged);
