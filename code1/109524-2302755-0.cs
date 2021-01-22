	[ParseChildren(false)]
	[PersistChildren(true)]
	public partial class RequiredFieldMarker : UserControl, ITextControl
	{
		[Category("Settings")]
		[PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
		public string Text
		{
			get
			{
				return lblName.Text;
			}
			set
			{
				lblName.Text = value;
			}
	}
