	/*
	 * Some controls will require that we set their "Site" property before
	 * we associate a IDesigner with them.  This "site" is used by the
	 * IDesigner to get services from the designer.  Because we're not
	 * implementing a real designer, we'll create a dummy site that
	 * provides bare minimum services and which relies on the framework
	 * for as much of its functionality as possible.
	 */
	class DummySite : ISite, IDisposable{
		DesignSurface designSurface;
		IComponent    component;
		string        name;
	
		public IComponent Component {get{return component;}}
		public IContainer Container {get{return designSurface.ComponentContainer;}}
		public bool       DesignMode{get{return false;}}
		public string     Name      {get{return name;}set{name = value;}}
		
		public DummySite(IComponent component){
			this.component = component;
			designSurface = new DesignSurface();
		}
		~DummySite(){Dispose(false);}
		protected virtual void Dispose(bool isDisposing){
			if(isDisposing)
				designSurface.Dispose();
		}
		public void Dispose(){
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		public object GetService(Type serviceType){return designSurface.GetService(serviceType);}
	}
	static void GetComponents(IComponent component, int level, Action<IComponent, int> action){
		action(component, level);
		bool visible, enabled;
		Control control = component as Control;
		if(control != null){
			/*
			 * Attaching the IDesigner sets the Visible and Enabled properties to true.
			 * This is useful when you're designing your form in Visual Studio, but at
			 * runtime, we'd rather the controls maintain their state, so we'll save the
			 * values of these properties and restore them after we detach the IDesigner.
			 */
			visible = control.Visible;
			enabled = control.Enabled;
			foreach(Control child in control.Controls)
				GetComponents(child, level + 1, action);
		}else visible = enabled = false;
		/*
		 * The TypeDescriptor class has a handy static method that gets
		 * the DesignerAttribute of the type of the component we pass it
		 * and creates an instance of the IDesigner class for us.  This
		 * saves us a lot of trouble.
		 */
		ComponentDesigner des = TypeDescriptor.CreateDesigner(component, typeof(IDesigner)) as ComponentDesigner;
		if(des != null)
			try{
				DummySite site;
				if(component.Site == null)
					component.Site = site = new DummySite(component);
				else site = null;
				try{
					des.Initialize(component);
					foreach(IComponent child in des.AssociatedComponents)
						GetComponents(child, level + 1, action);
				}finally{
					if(site != null){
						component.Site = null;
						site.Dispose();
					}
				}
			}finally{des.Dispose();}
		if(control != null){
			control.Visible = visible;
			control.Enabled = enabled;
		}
	}
	/* We'll use this in the ListComponents call */
	[DllImport("user32.dll", CharSet=CharSet.Auto)]
	static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
	const int WM_SETREDRAW = 11;
	void ListComponents(){
		/*
		 * Invisible controls and disabled controls will be temporarily shown and enabled
		 * during the GetComponents call (see the comment within that call), so to keep
		 * them from showing up and then disappearing again (or appearing to temporarily
		 * change enabled state), we'll disable redrawing of our window and re-enable it
		 * afterwards.
		 */
		SendMessage(Handle, WM_SETREDRAW, 0, 0);
		GetComponents(this, 0,
			/* You'll want to do something more useful here */
			(component, level)=>System.Diagnostics.Debug.WriteLine(new string('\t', level) + component));
		SendMessage(Handle, WM_SETREDRAW, 1, 0);
	}
	
