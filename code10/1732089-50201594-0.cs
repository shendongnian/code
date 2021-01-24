        private IMvxMessenger _messenger;
        public SearchHistoryFilterViewModel(IMvxMessenger messenger)
        {
            //_token = messenger.Subscribe...
            //messenger.Publish<SearchFilterMessage>(FilterByName());
            _messenger = messenger;
        }
        public void FilterByName()
        {
            Debug.WriteLine(Name);
            SearchFilterMessage message = new SearchFilterMessage(this, Name);
            //Send message
            _messenger.Publish<SearchFilterMessage>(message);
        }
