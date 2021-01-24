                   object obj =
     System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("A");
            Type utility = typeof(Utility);
            var mi = utility.GetMethod("CreateDynamicList", BindingFlags.Instance | BindingFlags.NonPublic);
            var m = mi.MakeGenericMethod(new Type[] { obj.GetType() });
            IEnumerable<A> obj=  m.Invoke(this, new object[] { obj }) as  IEnumerable<A>;
            //here you need to convert it to given type 
            // or you can do this 
            dynamic list = m.Invoke(this, new object[] { obj });
            list.Add(new A(); 
