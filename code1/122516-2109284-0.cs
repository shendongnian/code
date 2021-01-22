    class MainViewModel {
        public MainViewModel(IModel model, IController controller) {
           mModel = model;
           mController = controller;
           view.DataContext = this;
        }
        public ICommand ShowCommand = new DelegateCommand(o=> {
                      mResult = controller.GetSomeData(mSomeData);
                                                          });
    }
    class Controller : IController {
        public void OpenMainView() {
            new MainViewModel(somemodel, this);
        }
        public int GetSomeData(object anyKindOfData) {
          ShowWindow wnd = new ShowWindow(anyKindOfData);
          bool? res = wnd.ShowDialog();
          ...
        }
    }
