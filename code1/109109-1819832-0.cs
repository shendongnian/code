    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace CheckedListBoxScrollBarsWidth
    {
       public partial class Form1 : Form
       {
          const int LB_GETHORIZONTALEXTENT = 0x0193;
          const int LB_SETHORIZONTALEXTENT = 0x0194;
    
          const long WS_HSCROLL = 0x00100000L;
    
          const int SWP_FRAMECHANGED = 0x0020;
          const int SWP_NOMOVE = 0x0002;
          const int SWP_NOSIZE = 0x0001;
          const int SWP_NOZORDER = 0x0004;
    
          const int GWL_STYLE = (-16);    
    
          public Form1()
          {
             InitializeComponent();
             checkedListBox1.HorizontalScrollbar = true;
             AddStyle(checkedListBox1.Handle, (uint)WS_HSCROLL);
             SendMessage(checkedListBox1.Handle, LB_SETHORIZONTALEXTENT, 1000, 0);
          }
    
          [DllImport("user32.dll")]
          static extern int SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);
    
          [DllImport("user32.dll")]
          static extern uint GetWindowLong(IntPtr hwnd, int index);
    
          [DllImport("user32.dll")]
          static extern void SetWindowLong(IntPtr hwnd, int index, uint value);
    
          [DllImport("user32.dll")]
          static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X,
                int Y, int cx, int cy, uint uFlags);
    
    
          private void AddStyle(IntPtr handle, uint addStyle)
          {
             // Get current window style
             uint windowStyle = GetWindowLong(handle, GWL_STYLE);
             // Modify style
             SetWindowLong(handle, GWL_STYLE, windowStyle | addStyle);
             // Let the window know of the changes
             SetWindowPos(handle, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOZORDER | SWP_NOSIZE | SWP_FRAMECHANGED);
          }
       }
    }
