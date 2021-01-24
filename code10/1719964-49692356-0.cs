    class ConnectionSearch
    {
        public ConnectionSearch(string phrase, Action<object> addAction)
        {
            _searchPhrase = phrase;
            _addAction = addAction;
            _cancelSource = new CancellationTokenSource();
        }
    
        readonly string _searchPhrase = null;
        readonly Action<object> _addAction;
        readonly CancellationTokenSource _cancelSource;
    
        public void Cancel()
        {
            _cancelSource?.Cancel();
        }
    
        public async void PerformSearch()
        {
            await Task.Delay(300); //await 300ms between keystrokes
            if (_cancelSource.IsCancellationRequested)
                return;
    
            //continue your code keep checking for 
    
            //loop your dataset
            //call _addAction?.Invoke(uc);
        }
    }
