    public class ButtonColorViewModel
    {
        public Command ChangeButtons
        {
            get
            {
                return new Command(() => {
                   //Change here button background colors
                   BackgroundColorBtn1 = Color.Green; //or something
                });
            }
        }
    
        private _backgroundColorBtn1 = Color.White;
        public Color BackgroundColorBtn1
        {
            get { return _backgroundColorBtn1;}
            set
            {
                 if (value == _backgroundColorBtn1)
                     return;
                 _backgroundColorBtn1 = value;
                 NotifyOnPropertyChanged(nameof(BackgroundColorBtn1));
             }
        }
    }
