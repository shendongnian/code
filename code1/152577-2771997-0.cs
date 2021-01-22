    public class BList : List<T> where T : B {} same =  public class BList : List<B> {}
    public class C : A
    {
        public override List<B> Liste()
        {
            return new BList();
        }
    }
