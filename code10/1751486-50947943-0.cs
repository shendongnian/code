    public abstract DocumentWriter<T>
      where T : IDocumentArgs
    {
        (...)
        protected abstract void FillContent(T args);
    }
    public class ActualDocumentWriter : DocumentWriter<ActualDocumentArgs>
    {
        (...)    
        protected override void FillContent(ActualDocumentArgs args)
        {
            // Do stuff
        }
    }
