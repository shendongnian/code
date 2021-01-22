    class MainViewModel {
        public MainViewModel(IView view, IModel model, IController controller) {
           mModel = model;
           mController = controller;
           mView = view;
           view.DataContext = this;
        }
        public ICommand ShowCommand = new DelegateCommand(o=> {
                      mResult = controller.GetSomeData(mSomeData);
                                                          });
    }
    class Controller : IController {
        public void OpenMainView() {
            IView view = new MainView();
            new MainViewModel(view, somemodel, this);
        }
        public int GetSomeData(object anyKindOfData) {
          ShowWindow wnd = new ShowWindow(anyKindOfData);
          bool? res = wnd.ShowDialog();
          ...
        }
    }
