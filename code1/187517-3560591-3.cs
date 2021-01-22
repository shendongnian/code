    using System.Collections.Generic;
    namespace WPFListBoxSample
    {
        public class WPFListBoxModel
        {
            private IList<Category> _categories;
            public IList<Category> Categories
            {
                get
                {
                    if (_categories == null)
                        _categories = new List<Category>();
                    return _categories; }
                set { _categories = value; }
            }
        }
    }
