     public class ViewModel
    {
        public ICommand MouseEnterCommand
        {
            get
            {
                return new RelayCommand(a => this.Executemethod(a), p => Canexecutemethod(p));
            }
        }
        public bool Canexecutemethod(object a)
        {
            return true;
        }
        public void Executemethod(object p)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            string name = Convert.ToString(p);
            switch (name)
            {
                default:
                    break;
            }
        }
    }
