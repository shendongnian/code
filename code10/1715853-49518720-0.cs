    public Chapter Chapter
        {
            get
            {
                return _chapter;
            }
            set
            {
                if (value == _chapter|| value == null)
                    return;
                if (_chapter!= null)
                    _chapter.PropertyChanged -= ChapterPropertyChanged;
                _chapter= value;
                _chapter.PropertyChanged += ChapterPropertyChanged;
                UpdateProperties();
            }
        }
