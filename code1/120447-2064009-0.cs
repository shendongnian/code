    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace GlobalMouseEvents
    {
       public partial class Form1 : Form
       {
          public Form1()
          {
             GlobalMouseHandler gmh = new GlobalMouseHandler();
             gmh.TheMouseMoved += new MouseMovedEvent(gmh_TheMouseMoved);
             Application.AddMessageFilter(gmh);
    
             InitializeComponent();
          }
    
          void gmh_TheMouseMoved()
          {
             Point cur_pos = System.Windows.Forms.Cursor.Position;
             System.Console.WriteLine(cur_pos);
          }
       }
    
       public delegate void MouseMovedEvent();
    
       public class GlobalMouseHandler : IMessageFilter
       {
          private const int WM_MOUSEMOVE = 0x0200;
          
          public event MouseMovedEvent TheMouseMoved;
    
          #region IMessageFilter Members
    
          public bool PreFilterMessage(ref Message m)
          {
             if (m.Msg == WM_MOUSEMOVE)
             {
                if (TheMouseMoved != null)
                {
                   TheMouseMoved();
                }
             }
             // Always allow message to continue to the next filter control
             return false;
          }
    
          #endregion
       }
    }
