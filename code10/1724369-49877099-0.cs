    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Collections;
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main()
            {
                Node nums = new Node();
                nums.Insert(50);
                nums.Insert(17);
                nums.Insert(23);
                nums.Insert(12);
                nums.Insert(19);
                int min = nums.MinValue(nums.root);
                Console.WriteLine(min);
                Console.ReadLine();
            }
        }
        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
            public void DisplayNode()
            {
                Console.Write(Data + " ");
            }
            public Node root = null;
            public int MinValue(Node node)
            {
                Node current = node;
                /* loop down to find the leftmost leaf */
                while (current.Left != null)
                {
                    current = current.Left;
                }
                return (current.Data);
            }
            public void Insert(int i)
            {
                Node newNode = new Node();
                newNode.Data = i;
                if (root == null)
                    root = newNode;
                else
                {
                    Node current = root;
                    Node parent;
                    while (true)
                    {
                        parent = current;
                        if (i < current.Data)
                        {
                            current = current.Left;
                            if (current == null)
                            {
                                parent.Left = newNode;
                                break;
                            }
                            else
                            {
                                current = current.Right;
                                if (current == null)
                                {
                                    parent.Right = newNode;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
