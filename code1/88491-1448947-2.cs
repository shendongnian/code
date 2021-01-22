	using System;
	using System.Reflection;
	using System.Web.UI;
	
	public class AutoDataBindControl : Control
	{
		private static readonly object EventDataBinding;
		private bool needsDataBinding = false;
		static AutoDataBindControl()
		{
			try
			{
				FieldInfo field = typeof(Control).GetField(
					"EventDataBinding",
					BindingFlags.NonPublic|BindingFlags.Static);
				if (field != null)
				{
					AutoDataBindControl.EventDataBinding = field.GetValue(null);
				}
			}
			catch { }
			if (AutoDataBindControl.EventDataBinding == null)
			{
				// effectively disables the auto-binding feature
				AutoDataBindControl.EventDataBinding = new object();
			}
		}
		protected override void DataBind(bool raiseOnDataBinding)
		{
			base.DataBind(raiseOnDataBinding);
			// flag that databinding has taken place
			this.needsDataBinding = false;
		}
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			// check for the presence of DataBinding event handler
			if (this.HasEvents())
			{
				EventHandler handler = this.Events[AutoDataBindControl.EventDataBinding] as EventHandler;
				if (handler != null)
				{
					// flag that databinding is needed
					this.needsDataBinding = true;
					this.Page.PreRenderComplete += new EventHandler(this.OnPreRenderComplete);
				}
			}
		}
		void OnPreRenderComplete(object sender, EventArgs e)
		{
			// DataBind only if needed
			if (this.needsDataBinding)
			{
				this.DataBind();
			}
		}
	}
