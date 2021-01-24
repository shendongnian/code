    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static List<IDbEntityNode> flatDataStructure = null;
            static void Main(string[] args)
            {
                flatDataStructure = new List<IDbEntityNode>
                {
                    new ExceptionCategory("System Exception",1,0),
                    new ExceptionCategory("Index out of range",2,1),
                    new ExceptionCategory("Null Reference",3,1),
                    new ExceptionCategory("Invalid Cast",4,1),
                    new ExceptionCategory("OOM",5,1),
                    new ExceptionCategory("Argument Exception",6,1),
                    new ExceptionCategory("Argument Out Of Range",7,6),
                    new ExceptionCategory("Argument Null",8,6),
                    new ExceptionCategory("External Exception",9,1),
                    new ExceptionCategory("Com",10,9),
                    new ExceptionCategory("SEH",11,9),
                    new ExceptionCategory("Arithmatic Exception",12,1),
                    new ExceptionCategory("DivideBy0",13,12),
                    new ExceptionCategory("Overflow",14,12),
                };
                GenericNode<IDbEntityNode> root = new GenericNode<IDbEntityNode>();
                root.Parent = null;
                int rootId = 0;
                root.NodeInformation.Id = rootId;
                root.NodeInformation.ParentId = null;
                CreateGenericTree(root);
            }
            public static void CreateGenericTree<T>(GenericNode<T> parent) where T : IDbEntityNode, new()
            {
                List<IDbEntityNode> children = flatDataStructure.Where(x => x.ParentId == parent.NodeInformation.Id).ToList();
                foreach (IDbEntityNode child in children)
                {
                    GenericNode<T> newChild = new GenericNode<T>();
                    parent.Children.Add(newChild);
                    newChild.NodeInformation.Id = child.Id;
                    newChild.NodeInformation.ParentId = parent.NodeInformation.Id;
                    newChild.Parent = parent;
                    CreateGenericTree(newChild);
                }
            }
      
        }
        public class GenericNode<T> where T : new()
        {
            public T NodeInformation = new T(); 
            public GenericNode<T> Parent { get; set; }
            public List<GenericNode<T>> Children = new List<GenericNode<T>>();
        }
        public class IDbEntityNode
        {
             public int Id { get; set; }
             public int? ParentId { get; set; }
        }
        public class ExceptionCategory : IDbEntityNode
        {
            public string Data { get; set; }
            public ExceptionCategory(string data, int id, int parentId)
            {
                Id = id;
                ParentId = parentId;
                Data = data;
            }
        }
    }
