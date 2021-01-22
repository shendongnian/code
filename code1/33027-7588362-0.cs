    public abstract class MehBase<TSelf, TParam1, TParam2>
        where TSelf : MehBase<TSelf, TParam1, TParam2>, new()
    {
        public static TSelf CreateOne()
        {
            return new TSelf();
        }
    }
    public class Meh<TParam1, TParam2> : MehBase<Meh<TParam1, TParam2>, TParam1, TParam2>
    {
        public void Proof()
        {
            Meh<TParam1, TParam2> instanceOfSelf1 = Meh<TParam1, TParam2>.CreateOne();
            Meh<int, string> instanceOfSelf2 = Meh<int, string>.CreateOne();
        }
    } 
