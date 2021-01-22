      public abstract class BaseNode
      {
      }
    
      public abstract class AbstractNode<T> : BaseNode where T : BaseNode
      {
        public abstract NodeCollection<T> ChildNodes
        {
          get;
          set;
        }
      }
    
      public class ConcreteNodeA : AbstractNode<ConcreteNodeA>
      {
        public void Special() { }
    
        public override NodeCollection<ConcreteNodeA> ChildNodes
        {
          get;
          set;
        }
      }
    
      public class ConcreteNodeB : AbstractNode<ConcreteNodeA>
      {
        public void DoSomething()
        {
          ChildNodes[0].ChildNodes[0].ChildNodes[0].Special();
        }
    
        public override NodeCollection<ConcreteNodeA> ChildNodes
        {
          get;
          set;
        }
      }
      
      public class NodeCollection<T> : BindingList<T>
      {
        //add extra events here that notify what nodes were added, removed, or changed
      }
