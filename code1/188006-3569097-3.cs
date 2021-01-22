    using System;
    using System.Windows.Forms;
    
    namespace HotKeyManager
    {
      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
          HotKeyManager.RegisterHotKey(Keys.A, KeyModifiers.Alt);
          HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);     
        }
    
        void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
          MessageBox.Show("Hello");
        }
    
        protected override void SetVisibleCore(bool value)
        {      
          // Quick and dirty to keep the main window invisible      
          base.SetVisibleCore(false);
        }
      }
    }
