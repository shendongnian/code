    public class TreeItem<T> {
      public TreeItem() {
        Children = new List<TreeItem<T>>();
      }
      public void AddChild(T data) {
        Children.Add(new TreeItem<T>{Data = data, Parent = this});
      }
      public List<TreeItem<T>> Children{get;set;}
      public TreeItem<T> Parent {get;set;}
      public T Data {get;set;}
    }
