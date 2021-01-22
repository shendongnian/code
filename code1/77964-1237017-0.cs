                if (SecondChange != null)
                {
                    DateTime now = DateTime.Now;
                    foreach (Delegate d in SecondChange.GetInvocationList())
                    {
                        Console.WriteLine(d.DynamicInvoke(now));
                    }
                }
