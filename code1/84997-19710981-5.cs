       public bool FilterTextHasFocus
        {
            get { return filterTextHasFocus; }
            set
            {
                filterTextHasFocus = value;
                NotifyOfPropertyChange(() => FilterTextHasFocus);
            }
        }
