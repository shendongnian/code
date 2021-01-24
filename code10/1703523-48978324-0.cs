        private string _text;
        public string Text {
            get => _text;
            set {
                _text = value;
                OnPropertyChanged();
            }
        }
        private YourItemType _selectedItem;
        public YourItemType SelectedItem {
            get => _selectedItem;
            set {
                _selectedItem = value;
                Task.Run(() => GetValue(value));
                OnPropertyChanged();
            }
        }
        private void GetValue(YourItemType item){
            if(item == null) {
               Text = "invalid";
               return;
            }  
            //Do your work here - it's in the background already
            Text = resultOfWork;
        }
