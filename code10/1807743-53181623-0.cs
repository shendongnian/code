    using System;
    using System.Collections.Generic;
    
    class MainClass {
        public static void Main(string[] args) {
            PrintTree(ParseTree("(A(B(E)(F))(C(G)(H)))"), 0);
        }
        
        static Node ParseTree(string str) {
            var parent = new Stack<Node>();
            var hasLeft = new Stack<bool>();
            Node root = null;
    
            for (int i = 0; i < str.Length; i++) {
                if (str[i] == '(') {
                    if (str[++i] == ')') {
                        hasLeft.Pop();
                        hasLeft.Push(true);
                    }
                    else {
                        var node = new Node(str[i]);
                        
                        if (parent.Count > 0) {
                            if (hasLeft.Peek()) {
                                parent.Peek().right = node;
                            }
                            else {
                                parent.Peek().left = node;
                                hasLeft.Pop();
                                hasLeft.Push(true);
                            }
                        }
                        else {
                            root = node;
                        }
    
                        parent.Push(node);
                        hasLeft.Push(false);
                    }
                }
                else if (str[i] == ')') {
                    parent.Pop();
                    hasLeft.Pop();
                }
            }
    
            return root;
        }
    
        static void PrintTree(Node root, int depth) {
            if (root != null) {
                Console.WriteLine(new String(' ', depth) + root.val);
    
                if (root.left != null || root.right != null) {
                    Console.WriteLine(new String(' ', depth) +  "────┐");
                }
                
                PrintTree(root.left, depth + 4);
                PrintTree(root.right, depth + 4);
            }
        }
    }
    
    class Node {
        public Node left;
        public Node right;
        public char val;
    
        public Node(char val) {
            this.val = val;
        }
    }
