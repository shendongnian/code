        public ICommand DoSomething{ get; set; }
        
        DoSomething= new RelayCommand(doSomething);
        
        private void doSomething(object obj)
        {
            //Make it happen
        }
