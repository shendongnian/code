    partial class LinqClass
    {
        public event Action<LinqClass, ChangeAction> OnValidating;
        partial void OnValidate(ChangeAction action)
        {
            if (OnValidating != null)
            {
                OnValidating(this, action);
            }
        }
    }
