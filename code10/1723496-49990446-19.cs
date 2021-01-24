    public interface IViewModelBinder {
        void Bind(FrameworkElement view, object viewModel);
    }
    public class ViewModelBinder : IViewModelBinder {
        private readonly IServiceProvider serviceProvider;
        public ViewModelBinder(IServiceProvider serviceProvider) {
            this.serviceProvider = serviceProvider;
        }
        public void Bind(FrameworkElement view, object viewModel) {
            InitializeComponent(view);
            if (view.DataContext != null)
                return;
            var context = viewModel as NavigationContext;
            if (context != null) {
                var viewModelType = context.ViewModelType;
                if (viewModelType != null) {
                    viewModel = serviceProvider.GetService(viewModelType);
                }
                var parameter = context.Parameter;
                //TODO: figure out what to do with parameter
            }
            view.DataContext = viewModel;
        }
        static void InitializeComponent(object element) {
            var method = element.GetType().GetTypeInfo()
                .GetDeclaredMethod("InitializeComponent");
            method?.Invoke(element, null);
        }
    }
