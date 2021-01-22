    public abstract class AUserTracker
    {
        private IEnumerable<AUserTracker> _children;
        public IEnumerable<AUserTracker> Children
        {
            get { return _children; }
            set { _children = value; }
        }
        private bool? _userHasBeenThere;
        public bool UserHasBeenThere
        {
            get
            {
                if (_userHasBeenThere == null)
                {
                    _userHasBeenThere = false;
                    // Uses OR operator, any child will trigger the show up.
                    foreach (AUserTracker child in Children)
                        _userHasBeenThere |= child.UserHasBeenThere;
                }
                return _userHasBeenThere ?? false;
            }
        }
    }
