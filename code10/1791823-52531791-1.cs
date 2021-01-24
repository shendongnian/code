    List<A> lstA = new List<A>();
    lstA.Add(new A { Id = 1, Name = "A", Reg = 3 });
    lstA.Add(new A { Id = 2, Name = "B", Reg = 4 });
    lstA.Add(new A { Id = 3, Name = "C", Reg = 5 });
    List<A> lstB = new List<A>();
    lstB.Add(new A { Id = 4, Name = "D", Reg = 3 });
    lstB.Add(new A { Id = 5, Name = "E", Reg = 4 });
    lstB.Add(new A { Id = 6, Name = "F", Reg = 5 });
    var output = (from a in lstA
                  join b in lstB on a.Reg equals b.Reg
                  select new { a.Id, b.Name, b.Reg }).ToList();
