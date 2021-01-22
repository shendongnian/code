    class Base
    {
        public static T Get<T>(int id)
            where T : Base, new()
        {
            return new T() { ID = id };
        }
        public int ID { get; set; }
    }
Then you could write var p = Base.Get&lt;Puppy&gt;(10). Or, if you were feeling masochistic, you could write Puppy.Get&lt;Puppy&gt;(10) or even Kitty.Get&lt;Puppy&gt; ;) In all cases, you have to pass in the type explicitly, not implicitly.
