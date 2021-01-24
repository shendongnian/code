    internal class ClickedCommand : ICommand
    {
        private VModel _vModel;
        // private DataView _library;
        public ClickedCommand(VModel vModel)
        {
            _vModel = vModel;
            // _library = library;
        }
        public void Execute(object parameter)
        {
            // however you access it here.
            MessageBox.Show(_vModel.Library.GetData("id_model"));
            // MessageBox.Show(_library.GetData("id_model"));
        }
    }
