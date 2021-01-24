    public class ClassRemove : RemoveInfinite<object>
    {
        public override object Remove()
        {
            return new object();
        }
    }
    public class ClassA : SomeBaseClass, IRemove<object>
    {
        private RemoveInfinite<object> removeInfinite = new ClassRemove();
        public object Remove()
        {
            return removeInfinite.Remove();
        }
        public bool IsCompleted
        {
            get { return removeInfinite.IsCompleted; }
        }
    }
