    var querytest = ((from aliases in Table1.AsEnumerable()
              select new mylineitem
              {
                  Order = aliases.Field<int>("Priority")
                  Text = aliases.Field<string>("alias"),
                  cost = aliases.GetChildRows("Table1Table2")
                      .Where(codes => codes.Field<string>("class") != "*")
                          .Sum(codes => codes.GetChildRows("Table2Table3")
                              .Sum(data => data.Field<decimal>("cost")))
              }).Concat(from aliases in Table1.AsEnumerable()
                        join codes in Table2.AsEnumerable()
                            on aliases.Field<int>("ID") equals codes.Field<int>("ParentID")
                        join data in Table3.AsEnumerable()
                            on codes.Field<string>("code") equals data.Field<string>("code") into temp
                        where codes.Field<string>("class") == "*"
                        select new mylineitem
                        {
                            Order = aliases.Field<int>("Priority"),
                            Text = aliases.Field<string>("alias"),
                            cost = temp.Sum(x => x.Field<decimal>("cost"))
                        })).OrderBy(a => a.Order);
            foreach (var lineitem in querytest)
            {
                Console.WriteLine(lineitem.Text + " " + lineitem.cost);
            }
