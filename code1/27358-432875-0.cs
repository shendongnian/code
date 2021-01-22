        using (var ctx = new MyDataContext()) {
            string name = "Customer"; // type name
            Type ctxType = ctx.GetType();
            Type type = ctxType.Assembly.GetType(
                ctxType.Namespace + "." + name);
            ITable table = ctx.GetTable(type);
            foreach(var row in table) {
                Console.WriteLine(row); // works best if ToString overridden...
            }
        }
