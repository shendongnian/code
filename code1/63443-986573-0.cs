	public class Form1 : Form {
		private MouseMoveMessageFilter mouseMessageFilter;
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );
			this.mouseMessageFilter = new MouseMoveMessageFilter();
			this.mouseMessageFilter.TargetForm = this;
			Application.AddMessageFilter( this.mouseMessageFilter );
		}
		protected override void OnClosed( EventArgs e ) {
			base.OnClosed( e );
			Application.RemoveMessageFilter( this.mouseMessageFilter );
		}
		class MouseMoveMessageFilter : IMessageFilter {
			public Form TargetForm { get; set; }
			public bool PreFilterMessage( ref Message m ) {
				int numMsg = m.Msg;
				if ( numMsg == 0x0200 /*WM_MOUSEMOVE*/) {
					this.TargetForm.Text = string.Format( "X:{0}, Y:{1}", Control.MousePosition.X, Control.MousePosition.Y );
				}
				return false;
			}
		}
	}
