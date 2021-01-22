class ToolStripSystemTextBox : ToolStripControlHost
{
   public ToolStripSystemTextBox : base(new TextBox()) { }
   [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
   [TypeConverter(typeof(ExpandableObjectConverter))]
   public TextBox TextBox { get { return Control as TextBox; } }
}
