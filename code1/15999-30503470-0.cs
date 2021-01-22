    public static class ModelBaseMixins
    {
        public interface IHasStuff{ }
    
        public static void AddStuff<TObjectBase>(this TObjectBase objectBase, Stuff stuff) where TObjectBase: ObjectBase, IHasStuff
        {
            var stuffStore = objectBase.Get<IList<Stuff>>("stuffStore");
            stuffStore.Add(stuff);
        }
    }
