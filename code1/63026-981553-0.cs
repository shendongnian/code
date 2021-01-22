    public class MyList : List<MyClass>
    {
        public void Add(IActiveRecord item)
        {
            this.Add(new MyClass(item));
        }
        public void Add<T>(BindingListEx<T> list) where T : IActiveRecord
        {
            list.ToList().ForEach(x => Add(new MyClass(x)));
        }
    }
