    public interface IPageViewModel<out T> where T : class
    {
        string ViewName { get; set; }
        T SelectedItem { get; }
        IEnumerable<T> ItemsList { get; }
    }
