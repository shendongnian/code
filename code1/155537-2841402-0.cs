    public abstract class MyBase
    {
        public abstract void Save();
        ...
    }
    public class MyChild : MyBase
    {
         public override void Save()
         {
             ... save ...
         }
         ...
    }
