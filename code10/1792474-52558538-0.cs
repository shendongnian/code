    private string _text;
    public string Text
    {
        get { return _text; }
        set {
            if (value != _text) {
                _text = value;
                _specialCommand.TriggerCanExecuteChanged();
            }
        }
    }
