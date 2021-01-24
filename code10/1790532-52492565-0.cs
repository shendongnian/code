    var Bs = new[] {
        new B{ListA = new []{ new A { Id = 3 },new A { Id = 1 },new A { Id = 2 }} }
        ,new B{ListA = new List<A>{} }
        ,new B{ListA = null }
    };
    var result = Bs.Select(b =>
                    {
                        int i = 0;
                        if (b.ListA == null)
                        {
                            i = 2;
                        }
                        else if (!b.ListA.Any())
                        {
                            i = 1;
                        }
                        else {
                            b.ListA = b.ListA.OrderBy(a => a.Id).ToList();
                        }
                        return new { oIndex = i, value = b };
                    })
                    .OrderByDescending(x => x.oIndex)
                    .Select(g => g.value);
                           
