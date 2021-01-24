    /// <summary>
    /// Create a base page with generic support
    /// </summary>
    public class ContentPage<T> : ContentPage
    {
        /// <summary>
        /// This property basically type-casts the BindingContext to expected view-model type
        /// </summary>
        /// <value>The view model.</value>
        public T ViewModel { get { return (BindingContext != null) ? (T)BindingContext : default(T); } }
        /// <summary>
        /// Ensure ViewModel property change is raised when BindingContext changes
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            OnPropertyChanged(nameof(ViewModel));
        }
    }
