    class EntityTypeCounter : EntityVisitor
    {
        public int TotalLines { get; private set; }
        public int TotalArcs { get; private set; }
        #region EntityVisitor Members
        public void Visit(Arc arc) { TotalArcs++; }
        public void Visit(Line line) { TotalLines++; }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            Entity[] entities = new Entity[] { new Arc(), new Line(), new Arc(), new Arc(), new Line() };
            EntityTypeCounter counter = entities.Aggregate(
                new EntityTypeCounter(),
                (acc, item) => { item.Accept(acc); return acc; });
            Console.WriteLine("TotalLines: {0}", counter.TotalLines);
            Console.WriteLine("TotalArcs: {0}", counter.TotalArcs);
        }
    }
