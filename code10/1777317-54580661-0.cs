    public static List<Inventory> GetAll(string po, string cod)
    {
        using (var context = new ApplicationDbContext())
        {
            var Items = context.Inventorys
                .Where(p => p.CodigoPO == po || po == string.Empty)
                .Where(p => p.CodigoProduto == cod || cod == string.Empty).ToList();
            return Items;
        }
    }
