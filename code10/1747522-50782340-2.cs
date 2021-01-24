    class base_class
    {
        string abc;
        // note the word virtual here!
        public virtual int get_1()
        {
            return 1;
        }
        public  int get_number()
        {
            return get_1()+1;
        }
    }
