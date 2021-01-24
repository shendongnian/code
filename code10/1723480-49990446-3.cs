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
            var viewModelType = viewModel as Type;
            if (viewModelType != null) {
                viewModel = serviceProvider.GetService(viewModelType);
            }
            view.DataContext = viewModel;
        }
        static void InitializeComponent(object element) {
            var method = element.GetType().GetTypeInfo()
                .GetDeclaredMethod("InitializeComponent");
            if (method == null)
                return;
            method.Invoke(element, null);
        }
    }
