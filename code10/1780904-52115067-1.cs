          private ICommand _MyMethode;
                public ICommand MyMethode
                {
                    get
                    {
                        return _MyMethode ?? (_MyMethode = new CommandHandler<MyModel.item>(x => showMessage(x), _canExecute));
                    }
                }
    
    public void showMessage(string x)
    {
    MessageBox.Show(x);
    }
