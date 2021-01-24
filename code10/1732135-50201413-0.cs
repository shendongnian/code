    public DataRowView SelectedUniverse
    {
        get { return _SelectedUniverse; }
        set
        {
            _SelectedUniverse = value;
            UniverseChanged?.Invoke(this, EventArgs.Empty);
            // Or if you're using a C# version< 6:
            // if(UniverseChanged != null) UniverseChanged.Invoke(this, EventArgs.Empty);
            Debug.Print("Universe Changed in ViewModelController");
        }
    }
