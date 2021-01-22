    class Base<T> where T : Base<T>, new()
    {
        public static T Get(int id)
        {
            return new T() { ID = id };
        }
        public int ID { get; set; }
    }
    class Puppy : Base<Puppy>
    {
    }
    class Kitten : Base<Kitten>
    {
    }
You still need to pass the type back up to the base class, which allows you to write Puppy.Get(10) as expected.
But still, is there a reason to write it like that when var p = new Puppy(10) is just as concise and more idiomatic? Probably not.
