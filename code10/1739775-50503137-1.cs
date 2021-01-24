    class Billboard
    {
        public List<Figure> Figures { get; } = new List<Figure>();
        public void Add(Figure figure) => Figures.Add(figure);
        ... // more methods
    }
   
