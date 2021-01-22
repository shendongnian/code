    private void Loaded()
    {
        MyTreeNode d1 = new MyTreeNode();
        MyTreeNode d2 = new MyTreeNode();
        MyTreeNode d3 = new MyTreeNode();
        MyTreeNode d4 = new MyTreeNode();
        MyTreeNode d5 = new MyTreeNode();
        d1.AddNode(d2);
        d1.AddNode(d3);
        d2.AddNode(d4);
        d2.AddNode(d5);
        d1.CollectionChanged += (s, e) =>
        {
            MessageBox.Show("Tree Changed");
        };
        MyTreeNode d6 = new MyTreeNode();
        d3.AddNode(d6);
    }  
    public class MyTreeNode : ObservableCollection<MyTreeNode>
    {
        public void AddNode(MyTreeNode node)
        {
            this.Add(node);
            node.CollectionChanged += (s, e) => this.OnCollectionChanged(e);
        }
    }
