           int.TryParse(Console.ReadLine() , out int value);
                if(value != 0)
                {
                    val = value;
                    A a = new A(val);
                    A.Add(a);
                }
                else
                {
                    throw new Exception();
                }
