         string myVariable;
        public string MyVariable
        {
            get
            {
                return myVariable;
            }
            set
            {
                MyVariableHasBeenChanged();
                myVariable = value;
            }
        }
        private void MyVariableHasBeenChanged()
        {
            
        }
