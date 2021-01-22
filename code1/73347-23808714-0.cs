    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Microsoft.WindowsCE.Forms;
    namespace LogFontDemo
    {
        public class Form1 : System.Windows.Forms.Form
        {
            // Declare objects to draw the text.
            Font rotatedFont;
            SolidBrush redBrush;
            // Specify the text to roate, the rotation angle, 
            // and the base font. 
            private string rTxt = "abc ABC 123";
            private int rAng = 45;
            // Determine the vertial DPI setting for scaling the font on the  
            // device you use for developing the application. 
            // You will need this value for properly scaling the font on 
            // devices with a different DPI. 
            // In another application, get the DpiY property from a Graphics object  
            // on the device you use for application development: 
            //  
            //   Graphics g = this.CreateGraphics(); 
            //   int curDPI = g.DpiY; 
            private const int curDPI = 96;
            // Note that capabilities for rendering a font are 
            // dependant on the device. 
            private string rFnt = "Arial";
            public Form1()
            {
                // Display OK button to close application. 
                this.MinimizeBox = false;
                this.Text = "Rotated Font";
                // Create rotatedFont and redBrush objects in the custructor of 
                // the form so that they can be resued when the form is repainted. 
                this.rotatedFont = CreateRotatedFont(rFnt, rAng);
                this.redBrush    = new SolidBrush(Color.Red);
            }
            // Method to create a rotated font using a LOGFONT structure.
            Font CreateRotatedFont(string fontname, int angleInDegrees)
            {
                LogFont logf = new Microsoft.WindowsCE.Forms.LogFont();
                // Create graphics object for the form, and obtain 
                // the current DPI value at design time. In this case, 
                // only the vertical resolution is petinent, so the DpiY 
                // property is used. 
                Graphics g = this.CreateGraphics();
                // Scale an 18-point font for current screen vertical DPI.
                logf.Height = (int)(-18f * g.DpiY / curDPI);
                // Convert specified rotation angle to tenths of degrees.  
                logf.Escapement = angleInDegrees * 10;
                // Orientation is the same as Escapement in mobile platforms.
                logf.Orientation = logf.Escapement;
                logf.FaceName = fontname;
                // Set LogFont enumerations.
                logf.CharSet        = LogFontCharSet.Default;
                logf.OutPrecision   = LogFontPrecision.Default;
                logf.ClipPrecision  = LogFontClipPrecision.Default;
                logf.Quality        = LogFontQuality.ClearType;
                logf.PitchAndFamily = LogFontPitchAndFamily.Default;
                // Explicitly dispose any drawing objects created.
                g.Dispose();
                return Font.FromLogFont(logf);
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                if(this.rotatedFont == null)
                    return;
                // Draw the text to the screen using the LogFont, starting at 
                // the specified coordinates on the screen.
                e.Graphics.DrawString(rTxt,
                    this.rotatedFont,
                    this.redBrush,
                    75,
                    125,
                    new StringFormat(StringFormatFlags.NoWrap |
                        StringFormatFlags.NoClip));
            }
            protected override void Dispose(bool disposing)
            {
                // Dispose created graphic objects. Although they are  
                // disposed by the garbage collector when the application 
                // terminates, a good practice is to dispose them when they 
                // are no longer needed. 
                this.redBrush.Dispose();
                this.rotatedFont.Dispose();
                base.Dispose(disposing);
            }
            static void Main()
            {
                Application.Run(new Form1());
            }
        }
    }
