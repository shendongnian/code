    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class ReplicatedBaseType
        {
        }
    
        class NewType : ReplicatedBaseType
        {
        }
    
        class Document
        {
            ReplicatedBaseType BaseObject;
    
            Document()
            {
                BaseObject = new NewType();
            }
        }
        interface DalBase<out T>  where T: ReplicatedBaseType
        {
        }
    
        class DalBaseExample<T> : DalBase<T> where T: ReplicatedBaseType
        {
    
        }
        class DocumentTemplate
        {
            DalBase<ReplicatedBaseType> BaseType;
            DocumentTemplate ()
            {
                BaseType = new DalBaseExample<NewType>(); // no error here
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
            }
        }
    }
