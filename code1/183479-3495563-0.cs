    public class ILinkedItemFactory<T>
    {
        void YourMethodGoesHere();
    }
    public class MyList<LinkedItem, Factory> : List<LinkedItem>
        where Factory : ILinkedItemFactory<LinkedItem>
        where LinkedItem : MyItem, new()
    {
        public MyList(Factory factory)
        {
            factory.YourMethodGoesHere();
        }
    }
