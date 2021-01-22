    class Program : IView {
          private static ViewPresenter _presenter;
    
          static void Main(string[] args) {
          _presenter = new ViewPresenter( new Programm());  
         }
      }
