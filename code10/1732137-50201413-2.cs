    public DataRowView SelectedUniverse
    {
        get { return _SelectedUniverse; }
        set
        {
            _SelectedUniverse = value;
            UniverseChanged?.Invoke(this, EventArgs.Empty);
            // Or if you're using a C# version< 6:
            // var evtHandlers = UniverseChanged;
            // if(evtHandlers != null) evtHandlers.Invoke(this, EventArgs.Empty);
            Debug.Print("Universe Changed in ViewModelController");
        }
    }
