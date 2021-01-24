    internal class ClickedCommand : ICommand
    {
        private VModel vModel;
        // private DataView _library;
        public ClickedCommand(VModel vModel)
        {
            this.vModel = vModel;
            // _library = library;
        }
        public void Execute(object parameter)
        {
            // however you access it here.
            MessageBox.Show(vModel.Library.GetData("id_model"));
            // MessageBox.Show(_library.GetData("id_model"));
        }
    }
