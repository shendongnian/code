	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string rawHtml = RenderUserControlToString();
		}
		private string RenderUserControlToString()
		{
			UserControl myControl = (UserControl)LoadControl("WebUserControl1.ascx");
			using (TextWriter myTextWriter = new StringWriter())
			{
				using (HtmlTextWriter myWriter = new HtmlTextWriter(myTextWriter))
				{
					myControl.RenderControl(myWriter);
					return myTextWriter.ToString();
				}
			}
		}
		public override void VerifyRenderingInServerForm(Control control)
		{ /* Do nothing */ }
		public override bool EnableEventValidation
		{
			get { return false; }
			set	{ /* Do nothing */}
		}
	}
