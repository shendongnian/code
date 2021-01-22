    public class MyClass : IWeightedObject
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
            List<MyObject> list=new List<MyObject>();
            list.Add(new MyObject{Id=1,Weight=1});
            list.Add(new MyObject{Id=2,Weight=10});
            list.Add(new MyObject{Id=3,Weight=100});
            list.Add(new MyObject{Id=4,Weight=1000});
            MyObject randomlyselectedobject=WeightedRandomization.Choose(list.Cast<IWeightedObject>().ToList<IWeightedObject>(),r) as MyObject;
        }
    }
