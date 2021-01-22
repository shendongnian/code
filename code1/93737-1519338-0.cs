    interface ICanvas
    {
        // It's a good thing to use an interface
        // in this phase. It will allow you greater
        // freedom later.
    }
    class Canvas : ICanvas
    {
        private Shape.ShapeCollection _shapes;
        public Collection<Shape> Shapes
        {
            get { return _shapes; }
        }
        public Canvas()
        {
            _shapes = new Shape.ShapeCollection(this);
        }
    }
    class Shape
    {
        public class ShapeCollection : Collection<Shape>
        {
            private readonly ICanvas _parent;
            public ShapeCollection(ICanvas parent)
            {
                _parent = parent;
            }
            protected override void InsertItem(int index, Shape item)
            {
                item._canvas = _parent;
                base.InsertItem(index, item);
            }
            protected override void RemoveItem(int index)
            {
                this[index]._canvas = null;
                base.RemoveItem(index);
            }
            protected override void SetItem(int index, Shape item)
            {
                RemoveAt(index);
                InsertItem(index, item);
            }
            protected override void ClearItems()
            {
                while (this.Count != 0)
                    this.RemoveAt(this.Count - 1);
            }
        }
        private ICanvas _canvas;
        public ICanvas Canvas
        {
            get { return _canvas; }
        }
    }
