    public class WindowViewModel {
          public CloseCommand CloseCommand { get; set; }
          public bool CanCloseWindow { get; set; } = true;
          private bool CanExecuteCloseCommand () {
              return CanCloseWindow;
          }
          private void ExecuteCloseCommand(object parameter) {
              Window window = parameter as Window;
              window.Close();
          }
          // Constructor
          public WindowViewModel() {
               CloseCommand = new CloseCommand(CanExecuteCloseCommand(), ExecuteCloseCommand);
          }
    }
