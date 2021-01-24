        public RelayCommand MyButton { get; set; }
        
        public MainViewModel()
        {
            MyButton = new RelayCommand(Action);
        }
        
        public void Action(){
            Console.Writeline("Button Pressed");
        }
