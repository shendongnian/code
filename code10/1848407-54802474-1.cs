        public ICommand DoSomething{ get; set; }
        
        ReloadAll = new RelayCommand(doSomething);
        
        private void doSomething(object obj)
        {
            //Make it happen
        }
