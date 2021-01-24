    class Program
    {
        static void Main(string[] args)
        {
            var SelectedLine = (ILine)new Line(8);
            Console.WriteLine(SelectedLine.QtyOutstanding); // 0
            var prop = SelectedLine.GetType().GetProperty("QtyOutstanding");
            Console.WriteLine(prop.GetValue(SelectedLine)); // 8
            Console.ReadLine();
        }
    }
    class Line : ILine
    {
        public Line(int qtyOutstanding)
        {
            QtyOutstanding = qtyOutstanding;
        }
        public int QtyOutstanding { get; }
        int ILine.QtyOutstanding
        {
            get
            {
                return 0;
            }
        }
    }
    interface ILine
    {
        int QtyOutstanding { get; }
    }
