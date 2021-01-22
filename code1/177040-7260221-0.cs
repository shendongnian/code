    public class DispatchedTextBox : TextBox
        {
            DispatchEvent _propertyChanged = new DispatchEvent();
    
            protected override void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                this._propertyChanged.Fire(this, e);
            }
    
            protected override event PropertyChangedEventHandler PropertyChanged
            {
                add { this._propertyChanged.Add(value); }
                remove { this._propertyChanged.Remove(value); }
            }
        }
