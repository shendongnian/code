    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.ComponentModel;
    
    namespace SomeNamespace
    {
        class HighlightButton : Button
        {
            [DefaultValue(typeof(Color), "ControlLightLight")]
            [Category("Appearance")]
            [Description("The color that the Button should have when the mouse is over a visible part of it.")]
            public Color MouseoverColor { get; set; }
            // protected property to hold the original color, so we
            // can restore it when the mouse leaves
            protected Color OriginalColor { get; set; }
            
            public HighlightButton()
            {
                // set the default color
                this.MouseoverColor = SystemColors.ControlLightLight;
            }
    
            protected override void OnMouseEnter(EventArgs e)
            {
                this.OriginalColor = this.BackColor;
                this.BackColor = this.MouseoverColor;
                base.OnMouseEnter(e);
            }
    
            protected override void OnMouseLeave(EventArgs e)
            {
                this.BackColor = this.OriginalColor;
                base.OnMouseLeave(e);
            }
        }
    }
