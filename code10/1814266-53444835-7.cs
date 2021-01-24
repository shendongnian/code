    internal class ClickedCommand : ICommand
    {
        private VModel _vModel;
        public ClickedCommand(VModel vModel)
        {
            _vModel = vModel;
        }
        public event EventHandler CanExecuteChanged { add { } remove { } }
        public bool CanExecute(object parameter)
        {
                return true;
        }
        public void Execute(object parameter)
        {
            var id_movie = (int)parameter;
            var rowIndex = id_movie - 1;
            MessageBox.Show(_vModel.Library[rowIndex]["title"].ToString());
        }
    }
