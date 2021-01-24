        class MaskedEditViewModel
        {
        private string valueText;
        public string ValueText
        {
            get
            {
                return valueText;
            }
            set
            {
                SetValue(value); 
            }
        }
       
        private void SetValue(string data)
        {
            valueText = data;
            Application.Current.MainPage.DisplayAlert("Alert", string.Format("The current value is {0}", data),"OK");
        }
        }
