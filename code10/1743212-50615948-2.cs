    public class Info
    {
        public string Params { get; set; }
        public ICommand CommandValidate { get; set; }
    
        public Info()
        {
            this.Params = "Hi Nico";
            this.CommandValidate = new RelayCommand(()=> {
    
                Debug.WriteLine("This Method Invoke");
    
            });
        }
    }
