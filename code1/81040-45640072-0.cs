        private TreeViewItem _subsender;
        private object _senderTag;
        public TreeViewItem _sender
        {
            get {
                return _subsender;
            }
            set
            {
                _senderTag = value.Tag;
                _subsender = value;
            }
        }
