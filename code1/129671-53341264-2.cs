          public RelayCommand selectTreeViewCommand;
          [Bindable(true)]
          public RelayCommand SelectTreeViewCommand => selectTreeViewCommand ?? (selectTreeViewCommand = new RelayCommand(CanSelectTreeViewCommand, ExecuteSelectTreeViewCommand));
          private void ExecuteSelectTreeViewCommand(object obj)
          {
              Console.WriteLine(obj);
          }
          private bool CanSelectTreeViewCommand(object obj)
          {
              return true;
          }
