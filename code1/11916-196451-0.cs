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
        public Tree(T x, Tree<T> l, Tree<T> r)
        {
            this.Data = x;
            this.Left = l;
            this.Right = r;
        }
    }
    class Tree
    {
        public static Tree<T> Node<T>(T x, Tree<T> l, Tree<T> r) { return new Tree<T>(x, l, r); }
        public static Tree<int> Tree7 = Node(4, Node(2, Node(1, null, null), Node(3, null, null)),
                                                Node(6, Node(5, null, null), Node(7, null, null)));
        public static R XFoldTree<A, R>(Func<A, R, R, Tree<A>, R> nodeF, Func<Tree<A>, R> leafV, Tree<A> tree)
        {
            return Loop(nodeF, leafV, tree, x => x);
        }
        public static R Loop<A, R>(Func<A, R, R, Tree<A>, R> nodeF, Func<Tree<A>, R> leafV, Tree<A> t, Func<R, R> cont)
        {
            if (t == null)
                return cont(leafV(t));
            else
                return Loop(nodeF, leafV, t.Left, lacc =>
                       Loop(nodeF, leafV, t.Right, racc =>
                       cont(nodeF(t.Data, lacc, racc, t))));
        }
        public static R FoldTree<A, R>(Func<A, R, R, R> nodeF, R leafV, Tree<A> tree)
        {
            return XFoldTree((x, l, r, _) => nodeF(x, l, r), _ => leafV, tree);
        }
        public static Func<Tree<A>, Tree<A>> XNode<A>(A x, Tree<A> l, Tree<A> r)
        {
            return (Tree<A> t) => x.Equals(t.Data) && l == t.Left && r == t.Right ? t : Node(x, l, r);
        }
        // DiffTree: Tree<'a> * Tree<'a> -> Tree<'a * bool> 
        // return second tree with extra bool 
        // the bool signifies whether the Node "ReferenceEquals" the first tree 
        public static Tree<KeyValuePair<A, bool>> DiffTree<A>(Tree<A> tree, Tree<A> tree2)
        {
            return XFoldTree((A x, Func<Tree<A>, Tree<KeyValuePair<A, bool>>> l, Func<Tree<A>, Tree<KeyValuePair<A, bool>>> r, Tree<A> t) => (Tree<A> t2) =>
                Node(new KeyValuePair<A, bool>(t2.Data, object.ReferenceEquals(t, t2)),
                     l(t2.Left), r(t2.Right)),
                x => y => null, tree)(tree2);
        }
    }
    class Example
    {
        // original version recreates entire tree, yuck 
        public static Tree<int> Change5to0(Tree<int> tree)
        {
            return Tree.FoldTree((int x, Tree<int> l, Tree<int> r) => Tree.Node(x == 5 ? 0 : x, l, r), null, tree);
        }
        // here it is with XFold - same as original, only with Xs 
        public static Tree<int> XChange5to0(Tree<int> tree)
        {
            return Tree.XFoldTree((int x, Tree<int> l, Tree<int> r, Tree<int> orig) =>
                Tree.XNode(x == 5 ? 0 : x, l, r)(orig), _ => null, tree);
        }
    }
    class MyWPFWindow : Window 
    {
        void Draw(Canvas canvas, Tree<KeyValuePair<int, bool>> tree)
        {
            // assumes canvas is normalized to 1.0 x 1.0 
            Tree.FoldTree((KeyValuePair<int, bool> kvp, Func<Transform, Transform> l, Func<Transform, Transform> r) => trans =>
            {
                // current node in top half, centered left-to-right 
                var tb = new TextBox();
                tb.Width = 100.0; 
                tb.Height = 100.0;
                tb.FontSize = 70.0;
                    // the tree is a "diff tree" where the bool represents 
                    // "ReferenceEquals" differences, so color diffs Red 
                tb.Foreground = (kvp.Value ? Brushes.Black : Brushes.Red);
                tb.HorizontalContentAlignment = HorizontalAlignment.Center;
                tb.VerticalContentAlignment = VerticalAlignment.Center;
                tb.RenderTransform = AddT(trans, TranslateT(0.25, 0.0, ScaleT(0.005, 0.005, new TransformGroup())));
                tb.Text = kvp.Key.ToString();
                canvas.Children.Add(tb);
                // left child in bottom-left quadrant 
                l(AddT(trans, TranslateT(0.0, 0.5, ScaleT(0.5, 0.5, new TransformGroup()))));
                // right child in bottom-right quadrant 
                r(AddT(trans, TranslateT(0.5, 0.5, ScaleT(0.5, 0.5, new TransformGroup()))));
                return null;
            }, _ => null, tree)(new TransformGroup());
        }
    
        public MyWPFWindow(Tree<KeyValuePair<int, bool>> tree)
        {
            var canvas = new Canvas();
            canvas.Width=1.0;
            canvas.Height=1.0;
            canvas.Background = Brushes.Blue;
            canvas.LayoutTransform=new ScaleTransform(200.0, 200.0);
            Draw(canvas, tree);
            this.Content = canvas;
            this.Title = "MyWPFWindow";
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }
        TransformGroup AddT(Transform t, TransformGroup tg) { tg.Children.Add(t); return tg; }
        TransformGroup ScaleT(double x, double y, TransformGroup tg) { tg.Children.Add(new ScaleTransform(x,y)); return tg; }
        TransformGroup TranslateT(double x, double y, TransformGroup tg) { tg.Children.Add(new TranslateTransform(x,y)); return tg; }
    
        [STAThread]
        static void Main(string[] args)
        {
            var app = new Application();
            //app.Run(new MyWPFWindow(Tree.DiffTree(Tree.Tree7,Example.Change5to0(Tree.Tree7))));
            app.Run(new MyWPFWindow(Tree.DiffTree(Tree.Tree7, Example.XChange5to0(Tree.Tree7))));
        }
    }    
