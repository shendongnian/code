    public abstract Class EntityBase
    {
        private bool _changesAreTracking = false;
        private Dictionary<string, object> _changes = null;
        public EntityBase() {}
    
        public TrackChange(string propertyName, object value)
        {
            if(_changesAreTracking)
            {
                if(_changes == null) { _changes = new Dictionary<string, object>(); }
    
                _changes.Add(propertyName, value);
            }
        }
    
        public void StartTrackChanges()
        {
            _changesAreTracking = true;
        }
    
        public bool HasChanged()
        {
            bool returnThis = false;
    
            if(_changes != null && _changes.Keys.Count() > 0)
            {
                returnThis = true;
            }
    
            return returnThis;
        }
    
        public bool HasChanged(string propertyName)
        {
            bool returnThis = false;
    
            if(_changes != null && _changes.Keys.Contains(propertyName))
            {
                returnThis = true;
            }
    
            return returnThis;
        }
    }
