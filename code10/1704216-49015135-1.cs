    List<object> lst = new List<object> { "N", "N", -5.6, -1.00, 1.73, 7 };
                var result=
                lst.OrderByDescending(item =>
                {
                    double val = 0;
                    if (double.TryParse(item.ToString(), out val))
                    {
                        return val;
                    }
                    return double.MaxValue; /*dummy number*/
                }).ToList();
     foreach(var i in result)
                {
                    Console.WriteLine(i);
                }
