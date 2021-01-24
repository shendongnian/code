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
    			this.MouseEnter += (s, e) => { this.Size = EnterSize; };
    			this.MouseLeave += (s, e) => { this.Size = LeaveSize; };
    		}
    	}
    }
