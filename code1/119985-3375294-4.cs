    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    partial class UserControlStrings_MyControl : System.Web.UI.UserControl
    {
    
    
    	private MyTabsClass _Tabs = new MyTabsClass(this);
    
        [System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty)]
    	public MyTabsClass Tabs {
    		get { return _Tabs; }
    	}
    }
    
    public class MyTabsClass : System.Web.UI.ControlCollection
    {
    
    	public MyTabsClass(System.Web.UI.Control owner) : base(owner)
    	{
    	}
    
    	public override void Add(System.Web.UI.Control child)
    	{
    		base.Add(new MyTab(child));
    	}
    }
    
    
    public class MyTab : System.Web.UI.HtmlControls.HtmlGenericControl
    {
    
    	public MyTab(System.Web.UI.HtmlControls.HtmlGenericControl GenericControl) : base()
    	{
    		this.Label = GenericControl.Attributes("Label");
    		this.PanelId = GenericControl.Attributes("Panelid");
    	}
    
    
    	private string _Label = System.String.Empty;
    	public string Label {
    		get { return _Label; }
    		set { _Label = value; }
    	}
    
    	private string _PanelId = System.String.Empty;
    	public string PanelId {
    		get { return _PanelId; }
    		set { _PanelId = value; }
    	}
    
    	public override string ToString()
    	{
    		return this.Label + "-" + this.PanelId;
    	}
    }
