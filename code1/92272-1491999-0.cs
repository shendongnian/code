    public class YourClassHere
    {
        private YourClassHere _parent;
        private int _parentId;
    
        public YourClassHere Parent
        {
            get 
            { 
                if (_parent == null)
                {
                    _parent = DBWrapper.GetMyClassById(_parentId)
                }
                return _parent
            }
        }
    }
