    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace Solutions
    {
        public partial class MainWindow : Window
        {
            private static readonly string[] SuggestionValues = {
                "England",
                "USA",
                "France",
                "Estonia"
            };
    
            public MainWindow()
            {
                InitializeComponent();
                SuggestionBox.TextChanged += SuggestionBoxOnTextChanged;
            }
    
            private string _currentInput = "";
            private string _currentSuggestion = "";
            private string _currentText = "";
    
            private int _selectionStart;
            private int _selectionLength;
            private void SuggestionBoxOnTextChanged(object sender, TextChangedEventArgs e)
            {
                var input = SuggestionBox.Text;
                if (input.Length > _currentInput.Length && input != _currentSuggestion)
                {
                    _currentSuggestion = SuggestionValues.FirstOrDefault(x => x.StartsWith(input));
                    if (_currentSuggestion != null)
                    {
                        _currentText = _currentSuggestion;
                        _selectionStart = input.Length;
                        _selectionLength = _currentSuggestion.Length - input.Length;
    
                        SuggestionBox.Text = _currentText;
                        SuggestionBox.Select(_selectionStart, _selectionLength);
                    }
                }
                _currentInput = input;
            }
        }
    }
