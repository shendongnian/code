     public void OuterMethod<T>(T parameter) 
                {
                    T temp = parameter;
                    if (temp is string )
                        InnerMethod(Convert.ToString(temp));
                    if (temp is int)
                        InnerMethod(Convert.ToInt32(temp));// InnerMethod accepts an int or a string
                }
