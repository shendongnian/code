    using System.Drawing;
    using System.Windows.Forms;
    
    namespace InheritedButton
    {
    	public class ExpandButton : Button
    	{
    		public Size EnterSize { get; set; }
    		private Size _LeaveSize;
    		public Size LeaveSize
    		{
    			get
    			{
    				return (_LeaveSize);
    			}
    			set
    			{
    				_LeaveSize = value;
    				this.Size = LeaveSize;
    			}
    		}
    		public ExpandButton() : base()
    		{
    		}
            protected override void OnMouseEnter(EventArgs e)
            {
                this.Size = EnterSize;
                base.OnMouseEnter(e);
            }
            protected override void OnMouseLeave(EventArgs e)
            {
                this.Size = LeaveSize;
                base.OnMouseLeave(e);
            }
    	}
    }
