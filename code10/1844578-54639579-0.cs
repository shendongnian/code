    public class ViewModelLocator {
      public IKernel Kernel { get; set; }
  
      public ViewModelLocator() {
        Kernel = new StandardKernel();
      }
  
      public MainWindowViewModel MainWindowViewModel =>
        Kernel.Get<MainWindowViewModel>();
      public ProductDetailsWindowViewModel ProductDetailsWindowViewModel =>
        Kernel.Get<ProductDetailsWindowViewModel>();
    }
