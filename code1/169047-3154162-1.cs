    var desks = GetList(123, () => Model.GetDesks());
    var regions = GetList(456, () => Model.GetRegions());
    // ...
    private List<SelectListItem> GetList<T>(int id, Func<List<T>> getApps)
        where T : IDropdownItem
    {
        List<T> apps = getApps();
        List<SelectListItem> dropdown = apps.ConvertAll(c => new SelectListItem
            {
                Selected = c.Id == id,
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
        dropdown.Insert(0, new SelectListItem());
        return dropdown;
    }
    public interface IDropdownItem
    {
        int Id { get; }
        string Name { get; }
    }
    public class Desk : IDropdownItem { /* ... */ }
    public class Region : IDropdownItem { /* ... */ }
