    namespace BestLibrary
    {
        public interface GoodStuff
        {
             Goodies GiveMeGoodStuff(GoodiesType type);
        }
    }
    public enum GoodiesType { All, Type1, Type2 }
