    using System;
    using System.Windows.Forms;
    
    namespace Hector.Framework.Utils
    {
        public class Drag : Form
        {
            private bool isDraggable;
            private Control target;
            private int a, b;
    
            public Drag(){}
    
            public void Grab(Control control)
            {
                try
                {
                    this.isDraggable = true;
                    this.target = control;
                    this.a = Control.MousePosition.X - this.target.Left;
                    this.b = Control.MousePosition.Y - this.target.Top;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
    
            public void MoveObject(bool Horizontal = true, bool Vertical = true)
            {
                try
                {
                    if (this.isDraggable)
                    {
                        int x = Control.MousePosition.X,
                            y = Control.MousePosition.Y;
    
                        if (Horizontal)
                        {
                            this.target.Left = x - this.a;
                        }
                        if (Vertical)
                        {
                            this.target.Top = y - this.b;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
    
            public void Release()
            {
                this.isDraggable = false;
            }
        }
    }
