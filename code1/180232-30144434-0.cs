    public List<Control> GetAllChildControls(Control Root, Type FilterType = null)
    {
    	List<Control> AllChilds = new List<Control>();
    	foreach (Control ctl in Root.Controls) {
    		if (FilterType != null) {
    			if (ctl.GetType == FilterType) {
    				AllChilds.Add(ctl);
    			}
    		} else {
    			AllChilds.Add(ctl);
    		}
    		if (ctl.HasChildren) {
    			GetAllChildControls(ctl, FilterType);
    		}
    	}
    	return AllChilds;
    }
