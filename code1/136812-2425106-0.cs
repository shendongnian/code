    namespace WindowsFormsApplication1 {
    	public partial class Form1 : Form {
    		public Form1() {
    			InitializeComponent();
    		}
    
    		protected override void OnPaint(PaintEventArgs e) {
    			base.OnPaint(e);
    
    			e.Graphics.DrawLine(new Pen(Color.DarkGreen), 1,1, 3, 20 );
    			e.Graphics.DrawRectangle(new Pen(Color.Black), 10, 10, 20, 32 );
    		}
    	}
    }
