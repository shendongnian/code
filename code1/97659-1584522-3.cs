        var operators = new[] {
              new { Name = "+", Func = (Func<decimal,decimal,decimal>)((x,y)=>x+y) },
              new { Name = "-", Func = (Func<decimal,decimal,decimal>)((x,y)=>x-y) },
              new { Name = "/", Func = (Func<decimal,decimal,decimal>)((x,y)=>x/y) },
              new { Name = "*", Func = (Func<decimal,decimal,decimal>)((x,y)=>x*y) }
          };
        var options = from i in Enumerable.Range(1, 10)
                      select new {i, op=(
                        from op1 in operators
                        let v1 = op1.Func(5,5)
                        from op2 in operators
                        let v2 = op2.Func(v1, 5)
                        from op3 in operators
                        let v3 = op3.Func(v2,5)
                        where v3 == i
                        select "((5" + op1.Name + "5)" + op2.Name + "5)"
                           + op3.Name + "5").FirstOrDefault()};
        foreach (var opt in options)
        {
            Console.WriteLine(opt.i + ": " + opt.op);
        }
