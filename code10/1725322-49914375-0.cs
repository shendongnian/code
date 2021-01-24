    class Key
    {
        public int Vi { get; set; }
        public string Vs { get; set; }
      
        public Key(int vi, string vs)
        {
            Vi = vi;
            Vs = vs;
        }
    }
    var result = groups = list.GroupBy(b => new { b.vi, b.vs })
                              .Select(gr=> new { Key = Key(gr.vi,gr.vs)
                                               , Value = gr.Sum(x=>x.am)})
                              .ToList();
