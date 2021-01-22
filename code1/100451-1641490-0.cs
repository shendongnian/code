    namespace MyNS.Content {
    public class Tab : System.Web.UI.UserControl
	{
		private string _title;
		public Tab()
			: this(String.Empty)
		{
		}
		public Tab(string title)
		{
			_title = title;
		}
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
		private ITemplate tabContent = null;
		[
		TemplateContainer(typeof(TemplateControl)),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateInstance(TemplateInstance.Single),
		]
		public ITemplate TabContent
		{
			get
			{
				return tabContent;
			}
			set
			{
				tabContent = value;
			}
		}
		
	}
    }
