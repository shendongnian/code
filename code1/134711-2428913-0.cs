        public class Form1 : Form
        {
           IconLineShape myLine = new IconLineShape();
           ShapeContainer shapeContainer1 = new ShapeContainer();
           Panel panel1 = new Panel();
     
           public Form1()
           {
               this.panel1.Dock = DockStyle.Fill;
               // load your back image here
               this.panel1.BackgroundImage =
                   global::WindowsApplication22.Properties.Resources._13820t;
               this.panel1.Controls.Add(shapeContainer1);
      
               this.myLine.StartPoint = new Point(20, 30);
               this.myLine.EndPoint = new Point(80, 120);
               this.myLine.Parent = this.shapeContainer1;
     
               this.Controls.Add(panel1);
           }
       }
    
       public class IconLineShape : LineShape
       {
           Icon myIcon = SystemIcons.Exclamation;
     
           protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
           {
               e.Graphics.DrawIcon(myIcon, StartPoint.X, StartPoint.Y);
               base.OnPaint(e);
           }
    
           protected override void OnMouseMove(MouseEventArgs e)
           {
               if (draggable && 
                   e.Button == MouseButtons.Left &&
                   !this.StartPoint.Equals(e.Location))
               {
                   Region r = this.Region.Clone();
     
                   this.StartPoint = e.Location;
     
                   // try solution 1
                   this.Invalidate(r);
                
                   // solution 2; walk up to the upmost parent and refresh
                   // as said before, this.Invalidate() is to be preferred
                   Control currentParent = this.Parent;
                   while (currentParent.Parent != null)
                   {
                       currentParent = currentParent.Parent;
                   }
                   currentParent.Refresh();
               } 
           }
     
           private bool draggable = true;
    
           public bool Draggable
           {
               get { return this.draggable; }
               set { this.draggable = value; }
           }
       }
