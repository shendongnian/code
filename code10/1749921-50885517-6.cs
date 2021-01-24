    class Point
    {
        public int Val { get; set; }
        public string CordinateName {get; set;}
        public Point(int val, string cordinateName)
        {
            Val = val;
            CordinateName = cordinateName;
        }
        public virtual void Print()
        {
            Console.WriteLine(CordinateName + " Point: [{"+Val+"}]");
        }
    }
