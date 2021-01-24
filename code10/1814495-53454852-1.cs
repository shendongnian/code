      public class ClickedCommand2 : ICommand
    {
        private VModel _vModel;
    
        public ClickedCommand2(VModel vModel)
        {
            _vModel = vModel;
        }
        public event EventHandler CanExecuteChanged { add { } remove { } }
        public bool CanExecute(object parameter)
        {
            return true;
        }
    
        private static int a;
        public void Execute(object parameter)
        {
            var id_movie = (int)parameter;
            var rowIndex = id_movie - 1;
            a = (int)(_vModel.Library2[rowIndex]["id_movie"]);
        }
    
        private static int b = a;
        public static int Name
        {
            get { return b; }
            set { b = value; }
    
        }
    }
