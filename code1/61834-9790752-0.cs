    public interface IMainScreenView
    {
        event BoolHandler CloseView;
        bool IsDirty { get; set; }
        bool WillDiscardChanges();
    }
