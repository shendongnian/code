    class Drawing2D
    {
        public string Name { get; set; }
        public virtual List<IPoint> Points { get; set; }
        public Drawing2D(string name)
        {
            Name = name;
            Points = new List<IPoint>();
        }
        public virtual void Print()
        {
            Console.WriteLine("Drawing name: {"+Name+"}");
            foreach (var point in Points)
                point.Print();
        }
    }
    class Drawing3D : Drawing2D
    {
        public new List<IPoint> Points { get; set; }
        public Drawing3D(string name) : base(name)
        {
            Points = new List<IPoint>();
        }
        
        public override void Print()
        {
            Console.WriteLine("Drawing name: {"+Name+"}");
            foreach (var point in Points)
                point.Print();
        }
    }
