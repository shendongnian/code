    public class _LCToolsOptions : LCLogBase, ILCToolsOptions
    {
        public ILCLogOptions LCLog { get; set; }
        // instead of
        // public ILCLogOptions LCLogOptions { get; set; }
    }
