      public string Name
            {
                get { return name; }
                set
                {
                    name = value;
                    App.PVM.Add_patient.AddCanExecuteChanged();//PVM is a viewmodel
                    //The view model need to have INotifyPropertyChanged as a interface
               }
            }
