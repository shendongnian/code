    using System.Collections.Generic;
    
    public interface ICommon {}
    
    // Note the "class" part of the constraint
    public class ClassA<T> where T : class, ICommon
    {
        public ClassA()
        {
            ClassB b = new ClassB();
            IEnumerable<T> alist = new List<T>();
            b.Items = alist; 
        }   
    }
    
    public class ClassB
    {
        public IEnumerable<ICommon> Items { get; set;}
    }
