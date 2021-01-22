    public partial class FancyControl : Canvas
    {
        CheckBox myCheckBox;
        Label myLabel;
        public FancyControl() { }
        public FancyControl(CheckBox cb, Label l)
        {
            myCheckBox = cb;
            myLabel = l;
            Children.Add(myCheckBox);
            Children.Add(myLabel);
            //Formatting goes here
        }
        public string GetText()
        {
            return myLabel.Content.ToString();
        }
        public bool IsChecked()
        {
            return myCheckBox.IsChecked.Value;
        }
    }
