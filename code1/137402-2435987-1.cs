    class Foo
    {
        protected int id;
    
        public int GetID()
        {
            return (ID);
        }
    }
    
    class MutableFoo : Foo
    {
        public void SetID(int val)
        {
            id = val;
        }
    }
