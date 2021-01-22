    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    namespace WindowsFormsApplication3
    {
      [Designer("WindowsFormsApplication3.DecoratedPanelDesigner")]
      public class DecoratedPanel : Panel
      {
        #region decorationcanvas
    
        // this is an internal transparent panel.
        // This is our canvas we'll draw the lines on ...
        private class DecorationCanvas : Panel
        {
          public DecorationCanvas()
          {
            // don't paint the background
            SetStyle(ControlStyles.Opaque, true);
          }
    
          protected override CreateParams CreateParams
          {
            get
            {
              // use transparency
              CreateParams cp = base.CreateParams;
              cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
              return cp;
            }
          }
        }
    
        #endregion
    
        private DecorationCanvas _decorationCanvas;
    
        public DecoratedPanel()
        {
          // add our DecorationCanvas to our panel control
          _decorationCanvas = new DecorationCanvas();
          _decorationCanvas.Name = "myInternalOverlayPanel";
          _decorationCanvas.Size = ClientSize;
          _decorationCanvas.Location = new Point(0, 0);
          // this prevents the DecorationCanvas to catch clicks and the like
          _decorationCanvas.Enabled = false;
          _decorationCanvas.Paint += new PaintEventHandler(decoration_Paint);
          Controls.Add(_decorationCanvas);
        }
    
        protected override void Dispose(bool disposing)
        {
          if (disposing && _decorationCanvas != null)
          {
            // be a good citizen and clean up after yourself
    
            _decorationCanvas.Paint -= new PaintEventHandler(decoration_Paint);
            Controls.Remove(_decorationCanvas);
            _decorationCanvas = null;
          }
    
          base.Dispose(disposing);
        }
    
        void decoration_Paint(object sender, PaintEventArgs e)
        {
          // --- PAINT HERE ---
          e.Graphics.DrawLine(Pens.Red, 0, 0, ClientSize.Width, ClientSize.Height);
        }
    
        protected override void OnControlAdded(ControlEventArgs e)
        {
          base.OnControlAdded(e);
    
          ResetDecorationZOrder();
        }
    
        protected override void OnResize(EventArgs eventargs)
        {
          base.OnResize(eventargs);
          // make sure we're covering the panel control
          _decorationCanvas.Size = ClientSize;
        }
    
        protected override void OnSizeChanged(EventArgs e)
        {
          base.OnSizeChanged(e);
          // make sure we're covering the panel control
          _decorationCanvas.Size = ClientSize;
        }
    
        /// <summary>
        /// This is marked internal because it gets called from the designer
        /// to make sure our DecorationCanvas stays on top of the ZOrder.
        /// </summary>
        internal void ResetDecorationZOrder()
        {
          if (Controls.GetChildIndex(_decorationCanvas) != 0)
            Controls.SetChildIndex(_decorationCanvas, 0);
        }
    
      }
    
      /// <summary>
      /// Unfortunately, the default designer of the standard panel is not a public class
      /// So we'll have to build a new designer out of another one. Since Panel inherits from
      /// ScrollableControl, let's try a ScrollableControlDesigner ...
      /// </summary>
      public class DecoratedPanelDesigner : ScrollableControlDesigner
      {
        private IComponentChangeService _changeService;
    
        public override void Initialize(IComponent component)
        {
          base.Initialize(component);
    
          // Acquire a reference to IComponentChangeService.
          this._changeService = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
    
          // Hook the IComponentChangeService event
          if (this._changeService != null)
            this._changeService.ComponentChanged += new ComponentChangedEventHandler(_changeService_ComponentChanged);
        }
    
        /// <summary>
        /// Try and handle ZOrder changes at design time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _changeService_ComponentChanged(object sender, ComponentChangedEventArgs e)
        {
          Control changedControl = e.Component as Control;
          if (changedControl == null)
            return;
    
          DecoratedPanel panelPaint = Control as DecoratedPanel;
    
          if (panelPaint == null)
            return;
    
          // if the ZOrder of controls contained within our panel changes, the
          // changed control is our control
          if (changedControl.Equals(panelPaint))
            panelPaint.ResetDecorationZOrder();
        }
    
        protected override void Dispose(bool disposing)
        {
          if (disposing)
          {
            if (this._changeService != null)
            {
              // Unhook the event handler
              this._changeService.ComponentChanged -= new ComponentChangedEventHandler(_changeService_ComponentChanged);
              this._changeService = null;
            }
          }
    
          base.Dispose(disposing);
        }
    
        /// <summary>
        /// If the panel has BorderStyle.None, a dashed border needs to be drawn around it
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
          base.OnPaintAdornments(pe);
    
          Panel panel = Control as Panel;
          if (panel == null)
            return;
    
          if (panel.BorderStyle == BorderStyle.None)
          {
            using (Pen p = new Pen(SystemColors.ControlDark))
            {
              p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
              pe.Graphics.DrawRectangle(p, 0, 0, Control.Width - 1, Control.Height - 1);
            }
          }
        }
      }
    }
