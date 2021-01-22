	[ParseChildren(true), PersistChildren(true)]
	[ToolboxData(false /* don't care about drag-n-drop */)]
	public partial class MyControlWithNestedContent: System.Web.UI.UserControl, INamingContainer {
		// expose properties as attributes, etc
		
		/// <summary>
		/// "attach" template to child controls
		/// </summary>
		/// <param name="template">the exposed markup "property"</param>
		/// <param name="control">the actual rendered control</param>
		protected virtual void attachContent(ITemplate template, Control control) {
			if(null != template) template.InstantiateIn(control);
		}
	
		[PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public virtual ITemplate ChildContentOne { get; set; }
	
		[PersistenceMode(PersistenceMode.InnerProperty), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public virtual ITemplate ChildContentTwo { get; set; }
	
		protected override void CreateChildControls() {
			// clear stuff, other setup, etc
			// needed?
			base.CreateChildControls();
	
			this.EnsureChildControls(); // cuz...we want them?
		
			// using the templates, set up the appropriate child controls
			attachContent(this.ChildContentOne, this.plcChild1);
			attachContent(this.ChildContentTwo, this.plcChild2);
		}
	}
