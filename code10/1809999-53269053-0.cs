    private static void Main(string[] args)
    {
        Internal.Eng eng = new Internal.Eng();
        var tt = eng.GetType().Assembly;
        var dd = tt.GetType("Internal.DB");
        var kk = typeof(Action<>);
        Type[] targs = { dd };
        var qq = kk.MakeGenericType(targs);
        MethodInfo dynMethod = eng.GetType().GetMethod("Foo", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { qq }, null);
        dynMethod.Invoke(eng, new object[] {
            (Action<object>)(db=>{
                MethodInfo dynMethod2 = db.GetType().GetMethod("Wiz", BindingFlags.NonPublic | BindingFlags.Instance);
                dynMethod2.Invoke(db, new object[]{ });
            })
        });
    }
