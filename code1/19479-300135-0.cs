            public object execute(object obj) 
            {
                MethodInfo m = typeof(Parser).GetMethod(
                    "action", 
                    BindingFlags.Instance | BindingFlags.NonPublic, 
                    null, 
                    new Type[] { obj.GetType() }, 
                    null);
                m.Invoke(this, new object[] { obj });
                return obj; 
            } 
