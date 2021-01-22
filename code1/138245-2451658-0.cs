    public Object SelectedObject
    {
        get
        {
            return _selectedObject;
        }
        set
        {
            if (value != _selectedObject)
            {
                //HACK
                //Pulse 'null' between changes to reset listening list controls
                if (value != null)
                    SelectedObject = null;
    
                if (_selectedObject != null)
                    SelectedObjects.Remove(_selectedObject);
    
                _selectedObject = value;
                if (value != null)
                    SelectedObjects.Add(value);
            }
        }
    }
