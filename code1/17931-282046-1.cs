    public sealed class MySaveDialogResult
    {
        public static MySaveDialogResult NonOkResult(); // Null Object pattern
        public MySaveDialogResult( string filePath ) { ... }
        // encapsulate the dialog result
        public DialogResult DialogResult { get; private set; } 
        // some property that was set in the dialog
        public string FilePath { get; private set; }
        // another property set in the dialog
        public bool AllowOVerwrite { get; private set; }
    }
