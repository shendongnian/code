        public interface IMyInterface { }
        public class A : IMyInterface { }
        public class B : IMyInterface { }
        public List<IMyInterface> GetData<T>()
        {
            List<IMyInterface> myList = new List<IMyInterface>();
            if (typeof(T) == typeof(A))
            {
                myList.Add(new A());
            }
            if (typeof(T) == typeof(B))
            {
                myList.Add(new B());
            }
            return myList;
        }
