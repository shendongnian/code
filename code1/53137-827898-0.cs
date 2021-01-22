    public static class BlogDataAccess
    {
        private static Blog _Blg;
        public static Blog Blg
        {
            get
            {
                if(_Blg == null)
                    _Blg = new Blog();
                return _Blg;
            }
        }
    
    }
