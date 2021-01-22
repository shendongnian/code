    class Container
    {
        Dictionary<string, int> A { get; set; }
        Dictionary<string, string> B { get; set; }
        public Container()
        {
             // initialize the dictionary so they are not null
             // this can also be done on another place 
             // do it wherever it makes sense
             this.A = new Dictionary<string, int>();
             this.B = new Dictionary<string, string>();
        }
    }
    ...
    List<Container> l = new List<Container>();
    Container c = new Container();
    c.A.Add("id, 1);
    c.B.Add("name", "Tim");
    l.Add(c);
    ...
