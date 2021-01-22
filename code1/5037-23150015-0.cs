    class BST
    {
        public class Node
        {
            public Node Left { get; set; }
            public object Data { get; set; }
            public Node Right { get; set; }
            public Node()
            {
                Data = null;
            }
            public Node(int Data)
            {
                this.Data = (object)Data;
            }
            public void Insert(int Data)
            {
                if (this.Data == null)
                {
                    this.Data = (object)Data;
                    return;
                }
                if (Data > (int)this.Data)
                {
                    if (this.Right == null)
                    {
                        this.Right = new Node(Data);
                    }
                    else
                    {
                        this.Right.Insert(Data);
                    }
                }
                if (Data <= (int)this.Data)
                {
                    if (this.Left == null)
                    {
                        this.Left = new Node(Data);
                    }
                    else
                    {
                        this.Left.Insert(Data);
                    }
                }
            }
            public void TraverseInOrder()
            {
                if(this.Left != null)
                    this.Left.TraverseInOrder();
                Console.Write("{0} ", this.Data);
                if (this.Right != null)
                    this.Right.TraverseInOrder();
            }
        }
        public Node Root { get; set; }
        public BST()
        {
            Root = new Node();
        }
    }
