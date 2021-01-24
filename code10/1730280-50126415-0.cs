    class MyComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var _x = ((Webpage) x).getVisitCount();
            var _y = ((Webpage) y).getVisitCount();
            if (_x < _y)
            {
                return -1;
            }
            
            if (_x > _y)
            {
                return 1;
            }
            return 0;
        }
    }
