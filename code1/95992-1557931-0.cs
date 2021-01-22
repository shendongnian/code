    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication11
    {
      public partial class Form1 : Form
      {
        public const Int32 WM_SYSCOMMAND = 0x112;
        public const Int32 MF_BYPOSITION = 0x400;
        public const Int32 MYMENU1 = 1000;
        public const Int32 MUMENU2 = 1001;
    
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern bool InsertMenu(IntPtr hMenu,Int32 wPosition, Int32 wFlags, Int32 wIDNewItem,string lpNewItem);    
    
        public Form1()
        {
          InitializeComponent();
        }
    
        protected override void WndProc(ref Message m)
        {
          if (m.Msg == WM_SYSCOMMAND)
          {
            switch (m.WParam.ToInt32())
            {
              case MYMENU1:
                MessageBox.Show("Hi from My Menu 1¡¡¡¡");
                return;
              case MUMENU2:
                MessageBox.Show("Hi from My Menu 2¡¡¡¡");
                return;
              default:
                break;
            }
          }
          base.WndProc(ref m);
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
          IntPtr MenuHandle = GetSystemMenu(this.Handle, false);
          InsertMenu(MenuHandle, 5, MF_BYPOSITION, MYMENU1, "My Menu 1");
          InsertMenu(MenuHandle, 6, MF_BYPOSITION, MUMENU2, "My Menu 2");
        }
      }
    }
