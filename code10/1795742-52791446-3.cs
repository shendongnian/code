        private void OnClick(object parameter)
        {
            switch(parameter.ToString())
            {
                case "Button 1":
                    IsButton1Active = true;
                    IsButton2Active = false;
                    break;
                case "Button 2":
                    IsButton2Active = true;
                    IsButton1Active = false;
                    break;
            }
        }
