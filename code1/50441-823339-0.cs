    public class Widget : UserControl
    {
        // The Text property is virtual in the base Control class.
        // Override and call base.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("The Text property does not apply to the Widget class.")]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        // The CanFocus property is non-virtual in the base Control class.
        // Reintroduce with new, and throw if anyone dares to call it.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("The CanFocus property does not apply to the Widget class.")]
        public new bool CanFocus
        {
            get { throw new NotSupportedException(); }
        }
        // The Hide method is non-virtual in the base Control class.
        // Note that Browsable and DesignerSerializationVisibility are
        // not needed for methods, only properties.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("The Hide method does not apply to the Widget class.")]
        public new void Hide()
        {
            throw new NotSupportedException();
        }
    }
