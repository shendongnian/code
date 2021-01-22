    class MyObj
    {
        private int mID;
        public MyObj(int id)
        {
            this.mID = id;
        }
        public bool override Equals(Object obj)
        {
            MyObj mobj = obj as MyObj;
            if(mobj==null)
                return mobj;
            return this.mID == mobj.mID;
        }
    }
