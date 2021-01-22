    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        /// <summary>
        /// There's button 1 and button 2... button 1 is meant to start the dragging. Button 2 is meant to accept it
        /// </summary>
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            /// <summary>
            /// This is when button 1 starts the drag
            /// </summary>
            private void button1_MouseDown(object sender, MouseEventArgs e)
            {
                this.DoDragDrop(this, DragDropEffects.Copy);
            }
    
            /// <summary>
            /// This is when button 2 accepts the drag
            /// </summary>
            private void button2_DragEnter(object sender, DragEventArgs e)
            {
                e.Effect = DragDropEffects.Copy;
            }
    
    
            /// <summary>
            /// This is when the drop happens
            /// </summary>
            private void button2_DragDrop(object sender, DragEventArgs e)
            {
                // sender is always button2
            }
    
        }
    }
