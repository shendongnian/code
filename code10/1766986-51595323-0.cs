    public interface IFloatingActionButtonHost
    {
        bool ShouldBeHiddenWhenScrolling { get; }
        event Action LinkedScrollViewScrolled;
    }
