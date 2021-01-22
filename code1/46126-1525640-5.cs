    Expect.Once.On(view).Method("SubscribeMoveRequest").Will(
        Collect.Argument<PointDelegate>(0, delegate(PointDelegate del) { savedPointDelegate = del; }));
    
    public class Collect
    {
        public static CollectAction<T> Argument<T>(int index, CollectAction<T>.Collect collectDelegate)
        {
            CollectAction<T> collect = new CollectAction<T>(index, collectDelegate);
            return collect;
        }
    }
