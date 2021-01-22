    using System.Windows.Forms;
    
    namespace Whatever {
    	public class DBListBox : ListBox {
    		public DBListBox(): base() {
    			this.DoubleBuffered = true;
                // OR
                // this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    		}
    	}
    }
