    using System.ComponentModel;
    using System.Globalization;
    
    namespace System.Windows.Forms
    {
    	public static partial class Extensions
    	{
    		public static void ApplyResources(this Control target, CultureInfo culture = null)
    		{
    			ApplyResources(new ComponentResourceManager(target.GetType()), target, "$this", culture);
    		}
    
    		static void ApplyResources(ComponentResourceManager resourceManager, Control target, string name, CultureInfo culture = null)
    		{
    			// Preserve and reset Dock property
    			var dock = target.Dock;
    			target.Dock = DockStyle.None;
    			// Reset Anchor property
    			target.Anchor = AnchorStyles.Top | AnchorStyles.Left;
    			// Have the resource manager apply the resources to the given target
    			resourceManager.ApplyResources(target, name, culture);
    			// Iterate through the collection of children and recursively apply resources
    			foreach (Control child in target.Controls)
    			{
    				if (child is UserControl)
    					ApplyResources(child, culture);
    				else
    					ApplyResources(resourceManager, child, child.Name, culture);
    			}
    			// Restore Dock property
    			target.Dock = dock;
    		}
    	}
    }
