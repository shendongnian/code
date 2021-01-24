    public interface IA{
    }
    public interface IB : IA{
    }
    abstract class A<T> where T : IA 
    {
        abstract protected void Print(T obj);
    }
    abstract class B : A<IB> {
        override protected void Print(IB obj){
          // do something else
        }
    }
