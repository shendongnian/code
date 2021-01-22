        /// <summary>
	/// Represents a Col element.
	/// </summary>
	public class HtmlCol : HtmlGenericControl
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public HtmlCol()
			: base("col")
		{
		}
	}
	/// <summary>
	/// Collection of HtmlCols
	/// </summary>
	public class HtmlCols : List<HtmlCol>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public HtmlCols()
		{
		}
		/// <summary>
		/// Adds a col to the collection.
		/// </summary>
		/// <returns></returns>
		public HtmlCol Add()
		{
			var c = new HtmlCol();
			base.Add(c);
			return c;
		}
	}
	/// <summary>
	/// Represents a colgrpup tag element.
	/// </summary>
	internal class ColGroup : WebControl, INamingContainer
	{
		internal void RenderPrivate(HtmlTextWriter writer)
		{
			writer.Write("<colgroup>");
			base.RenderContents(writer);
			writer.Write("</colgroup>");
		}
		internal void RenderPrivate(HtmlTextWriter writer, HtmlCols cols)
		{
			writer.Write("<colgroup>");
			base.RenderContents(writer);
			foreach (var c in cols)
			{
				c.RenderControl(writer);
			}
			writer.Write("</colgroup>");
		}
	}
	
	[ToolboxData("<{0}:PlainGrid runat=server></{0}:Table>")]
	public class PlainGrid : GridView
	{
		private ColGroup _colGroup = null;
		private ITemplate _colGroupTemplate = null;
		private HtmlCols _cols = null;
		[TemplateContainer(typeof(ColGroup))]
		public virtual ITemplate ColGroupTemplate
		{
			get { return _colGroupTemplate; }
			set { _colGroupTemplate = value; }
		}
		protected override void CreateChildControls()
		{
			base.CreateChildControls();
			if (ColGroupTemplate != null)
			{
				ColGroupTemplate.InstantiateIn(_colGroup);
			}
		}
		protected override void Render(HtmlTextWriter writer)
		{
			// Get the base class's output
			var sw = new StringWriter();
			var htw = new HtmlTextWriter(sw);
			base.Render(htw);
			string output = sw.ToString();
			htw.Close();
			sw.Close();
			// Insert a <COLGROUP> element into the output
			int pos = output.IndexOf("<tr");
			if (pos != -1 && _colGroup != null)
			{
				sw = new StringWriter();
				htw = new HtmlTextWriter(sw);
				_colGroup.RenderPrivate(htw, _cols);
				output = output.Insert(pos, sw.ToString());
				htw.Close();
				sw.Close();
			}
			// Output the modified markup
			writer.Write(output);
		}
		/// <summary>
		/// Gets/Sets col items.
		/// </summary>
		public HtmlCols Cols
		{
			get { return _cols; }
			set { _cols = value; }
		}
		/// <summary>
		/// Default constructor
		/// </summary>
		public PlainGrid() 
		{
			base.AutoGenerateColumns = false;
			_colGroup = new ColGroup();
			_cols = new HtmlCols();
		}
	}
