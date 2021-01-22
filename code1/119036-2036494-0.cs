    public class MyList : IList<MyClass>
    {
        List<MyClass> _list;
        
        
        //Implement all IList members like so
        public int IndexOf(MyClass item)
        {
            return _list.IndexOf(item);
        }
 
        //Then help the type system a bit with these two static methods.
        public static implicit operator List<MyClass> (MyList mylist)
        {
            return mylist._list;
        }
        public static implicit operator MyList (List<MyClass> list)
        {
            return new MyList() { _list = list;}
        }
