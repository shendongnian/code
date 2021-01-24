                List<Object> x = new List<Object>();
                List<Object> y = new List<Object>();
                if (somecondition)
                {
                    x = x.Except(y).ToList();
                }
                else if (anotherCondition)
                {
                    x = x.Concat(y).ToList();
                }
