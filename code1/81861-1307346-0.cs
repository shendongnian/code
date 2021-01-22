     private ObservableCollection<Feed> _feeds;
            public ObservableCollection<Feed> Feeds
            {
                get
                {
                    if (_feeds == null)
                    {
                        var feedsQuery = from f in _db.Feed orderby f.Title select f;
                        _feeds = new ObservableCollection<Feed>();
                        foreach (var item in feedsQuery)
                        {
                            _feeds.Add(item);
                        }
                    }
                    return _feeds;
                }
            }
