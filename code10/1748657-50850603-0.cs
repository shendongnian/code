    public class DesignItemCommands
    {
        private ICommand setExtaExpressionValueCommand;
    
        public ICommand SetExtaExpressionValueCommand => setExtaExpressionValueCommand ?? (setExtaExpressionValueCommand = new CommandHandler(SetExtaExpressionValue, canExecute));
    
        private bool canExecute;
    
        public int ExtraExpressionValue { get; set; }
    
        public DesignItemCommands()
        {
            canExecute = true;
            ExtraExpressionValue = 1;
        }
    
        private void SetExtaExpressionValue(object parameter)
        {
            //I can use value here using variable ExtraExpressionValue 
        }
    }
