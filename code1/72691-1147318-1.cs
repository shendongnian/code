    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.ComponentModel;
    
    namespace WindowsFormsApplication1
    {
        class HighlightButton : Button
        {
            [Category("Appearance")]
            [Description("The background image that the Button should have when the mouse is over a visible part of it.")]
            public Image MouseoverBackgroundImage { get; set; }
            // property to hold the original background image while the mouse-over
            // image is displayed, so that we can restore it when the mouse leaves
            protected Image OriginalBackgroundImage { get; set; }
    
            protected override void OnMouseEnter(EventArgs e)
            {
                this.OriginalBackgroundImage = this.BackgroundImage;
                this.BackgroundImage = this.MouseoverBackgroundImage;
                base.OnMouseEnter(e);
            }
    
            protected override void OnMouseLeave(EventArgs e)
            {
                this.BackgroundImage = this.OriginalBackgroundImage;
                base.OnMouseLeave(e);
            }
        }
    }
