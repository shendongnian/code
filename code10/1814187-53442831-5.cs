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
            var rowIndex = (string)parameter[0];
            var stringToSearch = (string)parameter[1];
            // however you access it here.
            MessageBox.Show(_vModel.Library[rowIndex][stringToSearch]);
            // MessageBox.Show(_library[rowIndex][stringToSearch]);
        }
    }
