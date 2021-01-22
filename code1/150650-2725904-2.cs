    public class Menu
    {
        public Menu ParentMenu { get; set; }
        public int MenuId { get; set; }
    }
...
    static void Main(string[] args)
    {
        List<Menu> menus = new List<Menu>();
        for (int i = 0; i < 4; i++)
        {
            menus.Add(new Menu() { MenuId = i });
        }
    
        menus[2].ParentMenu = menus[0];
        menus[3].ParentMenu = menus[1];
    
        Console.WriteLine(BuildMenu(menus, 1));
        Console.Read();
    }
    
    static string BuildMenu(List<Menu> menus, int? parentId)
    {
        var query = menus.AsEnumerable();
        if (parentId.HasValue)
            query = query.Where(m => m.ParentMenu != null && m.ParentMenu.MenuId == parentId);
        else
            query = query.Where(m => m.ParentMenu == null);
    
        StringBuilder builder = new StringBuilder();
        foreach (Menu menu in query)
        {
            // build your string 
            builder.Append(menu.MenuId + ";");
        }
    
        return builder.ToString();
    }
