    public class ViewModel: INotifyPropertyChanged
    {
        private String _inputText;
        private ObservableCollection<String> _resultList = new ObservableCollection<string>();
        private String _resultText;
        public string InputText
        {
            get => _inputText;
            set
            {
                if (value == _inputText) return;
                _inputText = value;
                ProcessInput();
                OnPropertyChanged();
            }
        }
        private void ProcessInput()
        {
            ResultList.Clear();
            ResultText = GetUiFriendlyBarCode(InputText);
        }
        public ObservableCollection<string> ResultList
        {
            get => _resultList;
            set
            {
                if (Equals(value, _resultList)) return;
                _resultList = value;
                OnPropertyChanged();
            }
        }
        public string ResultText
        {
            get => _resultText;
            set
            {
                if (value == _resultText) return;
                _resultText = value;
                OnPropertyChanged();
            }
        }
        private string GetUiFriendlyBarCode(String input)
        {
            StringBuilder barCodeToDisplay = new StringBuilder();
            foreach (char character in input.ToString())
            {
                var uiFriendlyCharCode = GetUiFriendlyCharCode((int)character);
                barCodeToDisplay.Append(uiFriendlyCharCode);
                ResultList.Add(uiFriendlyCharCode);
            }
            return barCodeToDisplay.ToString();
        }
    //... implement GetUiFriendlyCharCode and INotifyPropertyChnaged
