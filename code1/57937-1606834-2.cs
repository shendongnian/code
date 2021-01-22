    class MyViewModel : ViewModelBase
    {
        public string Name
        {
            get { return _model.Name; }
            // The SetValue will create a undo event, and push it to the UndoManager
            set { SetValue(_model, "Name", value); }
        }
    }
