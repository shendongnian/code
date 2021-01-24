    List<object> lst = new List<object> { "N", "N", -5.6, -1.00, 1.73, 7 };
                var result=
                lst.OrderByDescending(item =>
                {
                    double val = 0;
                    if (double.TryParse(item.ToString(), out val))
                    {
                        return val;
                    }
                    return 999999; /*dummy number*/
                }).ToList();
