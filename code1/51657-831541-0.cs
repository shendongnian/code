    class MyControlViewModel : ViewModelBase
    {
        ICommand setTextCommand;
        string labelText;
        public ICommand SetTextCommand
        {
            get
            {
                if (setTextCommand == null)
                    setTextCommand = new RelayCommand(x => setText((string)x));
                return setTextCommand;
            }
        }
        //LabelText Property Code...
        void setText(string text)
        {
            LabelText = "You clicked: " + text;
        }
    }
