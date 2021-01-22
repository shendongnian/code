    public class MyClass : IWeighted
    {
        private int _id;
        private int _weight;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id=value;
            }
        }
        public int Weight
        {
            get
            {
                return this._weight;
            }
            set
            {
                this._weight=value;
            }
        }
    }
    public class ExampleClass
    {
        public void Randomize()
        {
            Random r=new Random();
            List<MyClass> list=new List<MyClass>();
            list.Add(new MyClass{Id=1,Weight=1});
            list.Add(new MyClass{Id=2,Weight=10});
            list.Add(new MyClass{Id=3,Weight=100});
            list.Add(new MyClass{Id=4,Weight=1000});
            MyClass randomlyselectedobject=WeightedRandomization.Choose(list.Cast<IWeighted>().ToList<IWeighted>(),r) as MyClass;
        }
    }
