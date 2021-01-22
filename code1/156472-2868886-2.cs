    [ToolboxBitmap(typeof(ErrorProvider))]
    [ProvideProperty("IconAlignment", typeof(Control))]
    public class MyErrorProvider : ErrorProvider
    {
        #region Base functionality overrides
        // We need to have a default that is explicitly different to 
        // what we actually want so that the designer generates calls
        // to our SetIconAlignment method so that we can then change
        // the base value. If the base class made the GetIconAlignment
        // method virtual we wouldn't have to waste our time.
        [DefaultValue(ErrorIconAlignment.MiddleRight)]
        public new ErrorIconAlignment GetIconAlignment(Control control)
        {
            return ErrorIconAlignment.MiddleLeft;
        }
        public new void SetIconAlignment(Control control, ErrorIconAlignment value)
        {
            base.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
        }
        #endregion
    }
