    public interface IWidgetId
    {
        int WidgetId { get; }
    }
    
    public class Widget
    { 
    }
    
    public ICollection<T> GetRelated<T>(Widget widget, IEnumerable<T> dbSet) where T : IWidgetId
    {
        return dbSet.Where(x => x.WidgetId == widget.WidgetId).ToList();
    }
