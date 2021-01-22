    public class MyTreeView : System.Windows.Forms.TreeView
    {
      // ...
     
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (e.Node.Tag.GetType() == typeof(MyDataObject))
                {
                    MyDataObject data = (MyDataObject)e.Node.Tag;
                    e.Node.Name = data.Number + ". " + data.Name;
                }
            }
         }
    }
