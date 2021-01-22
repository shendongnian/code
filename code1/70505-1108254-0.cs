    public class CrossTab
    {
        public VariableList Variables { get; set; }
        public ObservableCollection<VariableCode> ShownCodes
        {
            get
            {
                return new ObservableCollection<VariableCode>(
                    Variables
                        .SelectMany(variable => variable.VariableCodes)
                        .Where(code => code.IsShown)
                    );
            }
        }
    }
