    private List<Menu> GetMenuTree(List<Menu> list, int? idparent)
    {
        return list.Where(x => x.IDParent == idparent).Select(x => new Menu()
        {
            ID = x.ID,
            IDParent = x.IDParent,
            text= x.text,
            List = HasChildren(list, x.ID) ? GetMenuTree(list, x.ID) : null
        }).ToList();
    }
    public bool HasChildren(List<Menu> list, int? idparent)
    {
        return list.Where(x => x.IDParent == idparent).FirstOrDefault() != null;
    }
