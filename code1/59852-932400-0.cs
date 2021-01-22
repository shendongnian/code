    private static List<SelectListItem> priorities;
    public static IEnumerable<SelectListItem> PriorityMenu
    {
        get
        {
             if (priorities == null)
             {
                 priorities = new List<SelectListItem>();
                 foreach (var i in Enum.GetValues(typeof(Priority)))
                 {
                     priorities.Add( new SelectListItem
                                     {
                                         Text = Enum.GetName( typeof(Priority), i ),
                                         Value = i.ToString()
                                     });
                 }
             }
             return priorities;
        }
    }
