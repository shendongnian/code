using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ShowCoords(int x, int y)
        {
            this.MouseCoords.Text = string.Format("({0}, {1})", x, y);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.ShowCoords(e.X, e.Y);
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            // hook the mouse move of any control that is added to the form
            base.OnControlAdded(e);
            e.Control.MouseMove += new MouseEventHandler(Control_MouseMove);
        }
        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            // convert the mouse coords from control codes to screen coords
            // and then to form coords
            System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
            Point pt = this.PointToClient(ctrl.PointToScreen(e.Location));
            this.ShowCoords(pt.X, pt.Y);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseMove += this.Form1_MouseMove;
        }
    }
}
