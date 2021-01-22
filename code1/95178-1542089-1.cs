    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication9
    {
      internal struct LASTINPUTINFO
      {
        public uint cbSize;    
        public uint dwTime;
      }
    
      public partial class Form1 : Form
      {
    
        [DllImport("User32.dll")]
        public static extern bool LockWorkStation();
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO Dummy);
        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();
    
    public static uint GetIdleTime()
    {
      LASTINPUTINFO LastUserAction = new LASTINPUTINFO();
      LastUserAction.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(LastUserAction);
      GetLastInputInfo(ref LastUserAction);
      return ((uint)Environment.TickCount - LastUserAction.dwTime);
    }
    public static long GetTickCount()
    {
      return Environment.TickCount;
    }
    public static long GetLastInputTime()
    {
      LASTINPUTINFO LastUserAction = new LASTINPUTINFO();
      LastUserAction.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(LastUserAction);
      if (!GetLastInputInfo(ref LastUserAction))
      {
        throw new Exception(GetLastError().ToString());
      }
      return LastUserAction.dwTime;
    }
    
        public Form1()
        {
          InitializeComponent();
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
          if (GetIdleTime() > 10000)  //10 secs, Time to wait before locking
            LockWorkStation();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
          timer1.Start();
        }
      }
    }
