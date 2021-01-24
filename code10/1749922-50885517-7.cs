    class Drawing
    {
        public List<Point> Points { get; set; }
        public string Name {get; set;}
        public Drawing(string name)
        {
            Name = name;
            Points = new List<Point>();
        }
        
        public void Print()
        {
            Console.WriteLine("Drawing name: {"+Name+"} ");
            
            foreach (var point in Points)
                point.Print();
        } 
    }
