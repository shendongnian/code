    class GleeTest
    {
        static void Main() {
            Microsoft.Glee.GleeGraph oGleeGraph = new Microsoft.Glee.GleeGraph();
            Microsoft.Glee.Splines.ICurve oCurve =
               Microsoft.Glee.Splines.CurveFactory.CreateEllipse(
                   1, 1,
                   new Microsoft.Glee.Splines.Point(0, 0)
                   );
            Microsoft.Glee.Node strNode1 = new Microsoft.Glee.Node("Circle", oCurve);
           
            Microsoft.Glee.Node strNode3 = new Microsoft.Glee.Node("Diamond", oCurve);
            Microsoft.Glee.Node strNode4 = new Microsoft.Glee.Node("Standard", oCurve);
            Microsoft.Glee.Node strNode2 = new Microsoft.Glee.Node("Home", oCurve);
            oGleeGraph.AddNode(strNode1);
            oGleeGraph.AddNode(strNode2);
            oGleeGraph.AddNode(strNode3);
            oGleeGraph.AddNode(strNode4);
            Microsoft.Glee.Edge oGleeEdge1 =
               new Microsoft.Glee.Edge(strNode1, strNode2);
            Microsoft.Glee.Edge oGleeEdge2 =
            new Microsoft.Glee.Edge(strNode2, strNode1);
            Microsoft.Glee.Edge oGleeEdge3 =
            new Microsoft.Glee.Edge(strNode2, strNode2);
            Microsoft.Glee.Edge oGleeEdge4 =
            new Microsoft.Glee.Edge(strNode1, strNode3);
            Microsoft.Glee.Edge oGleeEdge5 =
            new Microsoft.Glee.Edge(strNode1, strNode4);
            Microsoft.Glee.Edge oGleeEdge6 =
          new Microsoft.Glee.Edge(strNode4, strNode1);
            oGleeGraph.AddEdge(oGleeEdge1);
            oGleeGraph.AddEdge(oGleeEdge2);
            oGleeGraph.AddEdge(oGleeEdge3);
            oGleeGraph.AddEdge(oGleeEdge4);
            oGleeGraph.AddEdge(oGleeEdge5);
            oGleeGraph.AddEdge(oGleeEdge6);
            oGleeGraph.CalculateLayout();
            System.Console.WriteLine("Circle position  " + oGleeGraph.FindNode("Circle").Center.X + "," + oGleeGraph.FindNode("Circle").Center.Y);
            System.Console.WriteLine("Home position = " + oGleeGraph.FindNode("Home").Center.X + "," + oGleeGraph.FindNode("Home").Center.Y);
            System.Console.WriteLine("Diamond position = " + oGleeGraph.FindNode("Diamond").Center.X + "," + oGleeGraph.FindNode("Diamond").Center.Y);
            System.Console.WriteLine("Standard position = " + oGleeGraph.FindNode("Standard").Center.X + "," + oGleeGraph.FindNode("Standard").Center.Y);
        
        }
    }
}
