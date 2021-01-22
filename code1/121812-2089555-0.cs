    public static List<T> SortResults<T>(List<T> listRow, 
                                         string sortColumn, bool ascending)
    {
        switch (ascending)
        {
            case true:
                return (from r in listRow
                        orderby r.GetType().GetField(sortColumn).GetValue(r)
                        select r).ToList();
            case false:
                return (from r in listRow
                        orderby r.GetType().GetField(sortColumn).GetValue(r) descending
                        select r).ToList();
            default:
                return listRow;
        }
    }
