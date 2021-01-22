    using System;
    using System.Windows.Forms;
    
    namespace myNameSpace.Forms.UserControls
    {
    	public class NumericUpDownSafe : NumericUpDown
    	{
    		EventHandler eventHandler = null;
    
    		public event EventHandler ValueChanged
    		{
    			add
    			{
    				eventHandler += value;
    				base.ValueChanged += value;
    			}
    
    			remove
    			{
    				eventHandler -= value;
    				base.ValueChanged -= value;
    			}
    		}
    
    		public decimal Value
    		{
    			get
    			{
    				return base.Value;
    			}
    			set
    			{
    				base.ValueChanged -= eventHandler;
    				base.Value = value;
    				base.ValueChanged += eventHandler;
    			}
    		}
    	}
    }
