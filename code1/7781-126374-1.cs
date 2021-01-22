    namespace ConsoleApplication2
    {
        using System;
        using System.Collections.Generic;
        using System.Collections;
    
        class B
        {
        }
    
        interface IEditable
        {
            void StartEdit();
            void StopEdit();
        }
    
        class EditContext<T> : IDisposable where T : IEditable
        {
            private T parent;
    
            public EditContext(T parent)
            {
                parent.StartEdit();
                this.parent = parent;
            }
    
            public void Dispose()
            {
                this.parent.StopEdit();
            }
        }
    
        class A : IEnumerable<B>, IEditable
        {
            private List<B> _myList = new List<B>();
            private bool editable;
    
            public void Add(B o)
            {
                if (!editable)
                {
                    throw new NotSupportedException();
                }
                _myList.Add(o);
            }
    
            public EditContext<A> ForEdition()
            {
                return new EditContext<A>(this);
            }
    
            public IEnumerator<B> GetEnumerator()
            {
                return _myList.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
    
            public void StartEdit()
            {
                this.editable = true;
            }
    
            public void StopEdit()
            {
                this.editable = false;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                A a = new A();
                using (EditContext<A> edit = a.ForEdition())
                {
                    a.Add(new B());
                    a.Add(new B());
                }
    
                foreach (B o in a)
                {
                    Console.WriteLine(o.GetType().ToString());
                }
    
                a.Add(new B());
    
                Console.ReadLine();
            }
        }
    }
