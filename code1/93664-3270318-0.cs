       public class LabeledProgressBar: ProgressBar
       {
          private string labelText;
    
          public string LabelText
          {
             get { return labelText; }
             set { labelText = value; }
          }
    
          public LabeledProgressBar() : base()
          { 
             this.SetStyle(ControlStyles.UserPaint, true);
             this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    
             this.Paint += OnLabelPaint;
          }
    
          public void OnLabelPaint(object sender, PaintEventArgs e)
          {
             using(Graphics gr = this.CreateGraphics())
    	    {
    		 string str = LabelText + string.Format(": {0}%", this.Value);
             LinearGradientBrush brBG = new LinearGradientBrush(e.ClipRectangle, 
                 Color.GreenYellow, Color.Green, LinearGradientMode.Horizontal);
             e.Graphics.FillRectangle(brBG, e.ClipRectangle.X, e.ClipRectangle.Y, 
                 e.ClipRectangle.Width * this.Value / this.Maximum, e.ClipRectangle.Height);
             e.Graphics.DrawString(str, SystemFonts.DefaultFont,Brushes.Black,  
                new PointF(this.Width / 2 - (gr.MeasureString(str, SystemFonts.DefaultFont).Width / 2.0F),
                this.Height / 2 - (gr.MeasureString(str, SystemFonts.DefaultFont).Height / 2.0F)));
	         }
           }
        }
     
