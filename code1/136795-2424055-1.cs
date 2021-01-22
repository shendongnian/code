        delegate void MyFunctionDelegate(string a);
        public void Main()
        {
            iterateObjects (delegate(string a){/*do something*/});
        }
    
        public void IterateObjects(MyFunctionDelegate akce)
        {
            foreach(string a in list)
            {
                akce(a);
            }
        }
