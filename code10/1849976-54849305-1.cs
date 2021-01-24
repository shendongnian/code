    B i = new B();
                i.a = new A();
                i.a.i = 10;
                MemberInfo[] mis = i.GetType().GetMembers();
                if (mis.FirstOrDefault(c => c.Name == "a") != null)
                {
                    MemberInfo mi = mis.FirstOrDefault(c => c.Name == "a");
    
                    A test = (A)mi.GetValue(i);
    
                    // handle A object here
                }
