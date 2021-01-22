    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    
    class Tree<T>   // use null for Leaf
    {
        public T Data { get; private set; }
        public Tree<T> Left { get; private set; }
        public Tree<T> Right { get; private set; }
        public Tree(T data, Tree<T> left, Tree<T> rright)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
        }
        public static Tree<T> Node<T>(T data, Tree<T> left, Tree<T> right)
        {
            return new Tree<T>(data, left, right);
        }
    }
