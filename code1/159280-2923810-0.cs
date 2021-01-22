    interface IDrawObject
    {
         public void Draw();
    }
    class Line : IDrawObject
    {
        private Point _startP;
        private Point _endP;
        
        public Line(Point startPoint; Poing endPoint)
        {
            _startP = startPoint;
            _endP = endPoint;
        }
        public void Draw()
        {
            //* call some generic draw processor to perform the action with your given parameters.
        }
    }
    
    class Rectangle : IDrawObject
    {
        //* your code.
        public void Draw()
        {
             //* call some generic draw processor to perform the action with your given parameters.
        }
    }
    //* then in your code, you could have something like this.
    List<IDrawObject> myObjectsINeedToDraw = new List<IDrawObject>();
    myObjectsINeedToDraw.Add(new Line(new Point(0, 0), new Point(10, 10));
    foreach(IDrawObject objectToDraw in myObjectsINeedToDraw)
    {
        //* will draw your object.
        objectToDraw.Draw();
    }
    //* in this way you will have unlimited history of your objects, and you will always can remove object from that list.
