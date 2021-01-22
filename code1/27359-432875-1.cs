        using (var ctx = new MyDataContext()) {
            string name = "Customers"; // property name
            ITable table = (ITable) ctx.GetType()
                .GetProperty(name).GetValue(ctx, null);
            foreach (var row in table) {
                Console.WriteLine(row); // works best if ToString overridden...
            }
        }
