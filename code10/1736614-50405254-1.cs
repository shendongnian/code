    public sealed class ViewModelTwo : Screen, IDisposable
    {
        ...
        public override void TryClose(bool? dialogResult = null)
        {
            Dispose();
            base.TryClose(dialogResult);
        }
        public void Dispose()
        {
            _disposeList?.Dispose();
        }
    }
