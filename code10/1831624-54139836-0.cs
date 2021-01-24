    public class SaveSuccessfulObjects : ISavePowerShellResult
    {
        private IEnumerable<PSObject> _objects;
        public SaveSuccessfulObjects(IEnumerable<PSObject> objects) => _objects = objects;
        public void Save()
        {
            foreach (var psobject in _objects)
            {
                // save to sql database
            }
        }
    }
    public class SaveErrors : ISavePowerShellResult
    {
        private IEnumerable<ErrorRecord> _errors;
        public SaveErrors(IEnumerable<ErrorRecord> errors) => _errors = errors;
        public void Save()
        {
            foreach (var record in _errors)
            {
                // save error to xml file
            }
        }
    }
