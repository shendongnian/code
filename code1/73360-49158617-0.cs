    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    public class ContainerMessageFilter : IMessageFilter {
		private const int WM_MOUSEMOVE = 0x0200;
		public event EventHandler MouseEnter;
		public event EventHandler MouseLeave;
		private bool insideContainer;
		private readonly IEnumerable<IntPtr> handles;
		public ContainerMessageFilter( Control container ) {
			handles = CollectContainerHandles( container );
		}
		private static IEnumerable<IntPtr> CollectContainerHandles( Control container ) {
			var handles = new List<IntPtr> { container.Handle };
			RecurseControls( container.Controls, handles );
			return handles;
		}
		private static void RecurseControls( IEnumerable controls, List<IntPtr> handles ) {
			foreach ( Control control in controls ) {
				handles.Add( control.Handle );
				RecurseControls( control.Controls, handles );
			}
		}
		public bool PreFilterMessage( ref Message m ) {
			if ( m.Msg == WM_MOUSEMOVE ) {
				if ( handles.Contains( m.HWnd ) ) {
					// Mouse is inside container
					if ( !insideContainer ) {
						// was out, now in
						insideContainer = true;
						OnMouseEnter( EventArgs.Empty );
					}
				}
				else {
					// Mouse is outside container
					if ( insideContainer ) {
						// was in, now out
						insideContainer = false;
						OnMouseLeave( EventArgs.Empty );
					}
				}
			}
			return false;
		}
		protected virtual void OnMouseEnter( EventArgs e ) {
			var handler = MouseEnter;
			handler?.Invoke( this, e );
		}
		protected virtual void OnMouseLeave( EventArgs e ) {
			var handler = MouseLeave;
			handler?.Invoke( this, e );
		}
	}
