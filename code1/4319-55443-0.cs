    static public IQueryable<Activity> AddCondition(
        this IQueryable<Activity> results,
        DropDownList ddl, 
        Expression<Func<Activity, bool>> containsCondition)
    {
        if (!string.IsNullOrEmpty(ddl.SelectedItem.Text))
            results = results.Where(containsCondition);
        return results;
    }
    static public IQueryable<Activity> AddCondition(
        this IQueryable<Activity> results,
        CheckBox chk, 
        Expression<Func<Activity, bool>> emptyCondition)
    {
        if (chk.Checked)
            results = results.Where(emptyCondition);
        return results;
    }
