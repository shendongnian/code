          private ICommand _MyMethode;
                public ICommand MyMethode
                {
                    get
                    {
                        return _MyMethode ?? (_MyMethode = new CommandHandler<MyModel.item>(x => showMessage(x), _canExecute));
                    }
                }
    
    public void showMessage(MyModel.item x)
    {
    MessageBox.Show(x.Info);
    }
