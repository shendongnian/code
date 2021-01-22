    using Microsoft.VisualBasic.PowerPacks;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace LineShapeTest {
    
        public partial class Form1 : Form {
    
            /*  Designer support through
             *  Create Panel
             *  Set panel's background image
             *  Add LineShape
             *  Add IconShape
             *  Create IconicLineShapeHelper
             */
            public Form1() {
                InitializeComponent();
                IconicLineShapeHelper arbitrary1 = new IconicLineShapeHelper(lineShape1, iconShape1);
                IconicLineShapeHelper arbitrary2 = new IconicLineShapeHelper(lineShape2, iconShape2);
            }
    
            private Panel panel1;
            private ShapeContainer shapeContainer1;
            private LineShape lineShape1;
            private IconShape iconShape1;
            private ShapeContainer shapeContainer2;
            private LineShape lineShape2;
            private IconShape iconShape2;
    
        #region [ Form1.Designer.cs ]
            private System.ComponentModel.IContainer components = null;
            protected override void Dispose(bool disposing) {
                if (disposing && (components != null)) {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            #region Windows Form Designer generated code
            private void InitializeComponent() {
                this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
                this.panel1 = new System.Windows.Forms.Panel();
                this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
                this.iconShape1 = new LineShapeTest.IconShape();
                this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
                this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
                this.iconShape2 = new LineShapeTest.IconShape();
                this.panel1.SuspendLayout();
                this.SuspendLayout();
                // 
                // lineShape1
                // 
                this.lineShape1.Name = "lineShape1";
                this.lineShape1.X1 = 13;
                this.lineShape1.X2 = 88;
                this.lineShape1.Y1 = 11;
                this.lineShape1.Y2 = 34;
                // 
                // panel1
                // 
                this.panel1.BackgroundImage = global::LineShapeTest.Properties.Resources._13820t;
                this.panel1.Controls.Add(this.shapeContainer1);
                this.panel1.Location = new System.Drawing.Point(27, 24);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(162, 122);
                this.panel1.TabIndex = 1;
                // 
                // shapeContainer1
                // 
                this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
                this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
                this.shapeContainer1.Name = "shapeContainer1";
                this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
                this.iconShape1,
                this.lineShape1});
                this.shapeContainer1.Size = new System.Drawing.Size(162, 122);
                this.shapeContainer1.TabIndex = 0;
                this.shapeContainer1.TabStop = false;
                // 
                // iconShape1
                // 
                this.iconShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                this.iconShape1.Location = new System.Drawing.Point(88, 64);
                this.iconShape1.Name = "iconShape1";
                this.iconShape1.Size = new System.Drawing.Size(32, 32);
                // 
                // shapeContainer2
                // 
                this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
                this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
                this.shapeContainer2.Name = "shapeContainer2";
                this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
                this.iconShape2,
                this.lineShape2});
                this.shapeContainer2.Size = new System.Drawing.Size(292, 266);
                this.shapeContainer2.TabIndex = 2;
                this.shapeContainer2.TabStop = false;
                // 
                // lineShape2
                // 
                this.lineShape2.Name = "lineShape2";
                this.lineShape2.X1 = 48;
                this.lineShape2.X2 = 123;
                this.lineShape2.Y1 = 187;
                this.lineShape2.Y2 = 210;
                // 
                // iconShape2
                // 
                this.iconShape2.Location = new System.Drawing.Point(136, 220);
                this.iconShape2.Name = "iconShape2";
                this.iconShape2.Size = new System.Drawing.Size(75, 23);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(292, 266);
                this.Controls.Add(this.panel1);
                this.Controls.Add(this.shapeContainer2);
                this.Name = "Form1";
                this.Text = "Form1";
                this.panel1.ResumeLayout(false);
                this.ResumeLayout(false);
    
            }
            #endregion
        }
        #endregion
    
        public class IconicLineShapeHelper {
            ShapeContainer _container;
            LineShape _line;
            IconShape _icon;
            public IconicLineShapeHelper(LineShape line, IconShape icon) {
                _container = line.Parent;
                _line = line;
                _icon = icon;
                _container.MouseMove += new MouseEventHandler(_container_MouseMove);
            }
            void _container_MouseMove(object sender, MouseEventArgs e) {
                if (e.Button == MouseButtons.Left) {
                    _line.StartPoint = e.Location;
                    _icon.Location = e.Location;
                }
            }
        }
        public class IconShape : RectangleShape {
            Icon _icon = SystemIcons.Exclamation;
            public IconShape() {
                this.Size = new System.Drawing.Size(32, 32);
                this.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            }
            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
                e.Graphics.DrawIcon(_icon, this.Location.X, this.Location.Y);
                base.OnPaint(e);
            }
        }
    }
