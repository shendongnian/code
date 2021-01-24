    using System.IO;
    using System;
    
    class Node
    {
        public int[] item = new int[11];
        public Node left;
        public Node right;
        public void display()
        {
            Console.Write("[");
            Console.Write(item);
            Console.Write("]");
        }
    }
    
    class Tree
    {
        public Node root;
    
        public Tree()
        {
            root = null;
        }
    
        public Node Returnroot()
        {
            return root;
        }
    
        public void Insert(int id)
        {
            Node newnode = new Node();
            newnode.item[10] = id; // HERE (1/5)
            if (root == null)
                root = newnode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (id < current.item[10]) // HERE (2/5)
                    {
                        current = current.left;
                            if (current == null)
                            {
                                parent.left = newnode;
                                return;
                            }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newnode;
                            return;
                        }
                    }
                }
            }
        }
    
        public void Inorder(Node Root)
        {
            if (Root != null)
            {
                Inorder(Root.left);
                Console.WriteLine(Root.item[10] + " "); // HERE (3/5)
                Inorder(Root.right);
            }
        }
    
        public void Preorder(Node Root)
        {
            if (Root != null)
            {
                Console.WriteLine(Root.item[10] + " "); // HERE (4/5)
                Preorder(Root.left);
                Preorder(Root.right);
            }
        }
    
        public void Postorder(Node Root)
        {
            if (Root != null)
            {
                Postorder(Root.left);
                Postorder(Root.right);
                Console.WriteLine(Root.item[10] + " "); // HERE (5/5)
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Tree BST = new Tree();
            BST.Insert(30);
            BST.Insert(35);
            BST.Insert(57);
            BST.Insert(15);
            BST.Insert(63);
            BST.Insert(49);
            BST.Insert(89);
            BST.Insert(77);
            BST.Insert(67);
            BST.Insert(98);
            BST.Insert(91);
            Console.WriteLine("inOrder Traversal :  ");
            BST.Inorder(BST.Returnroot());
            Console.WriteLine("  ");
            Console.WriteLine();
            Console.WriteLine("PreOrder Traversal :  ");
            BST.Preorder(BST.Returnroot());
            Console.WriteLine("  ");
            Console.WriteLine();
            Console.WriteLine("PostOrder Traversal :  ");
            BST.Postorder(BST.Returnroot());
            Console.WriteLine("  ");
            Console.WriteLine();
    
            Console.ReadKey();
        }
    }
