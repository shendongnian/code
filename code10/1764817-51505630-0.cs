    abstract class A<T> where T : IA 
    {
        public interface IA{
        }
        abstract protected void Print(T obj);
    }
    abstract class B : A<IB> {
        public interface IB : IA{
        }
        override protected void Print(IB obj){
          // do something else
        }
    }
