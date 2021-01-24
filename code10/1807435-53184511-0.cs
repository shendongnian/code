    public class OpenCHMInMessageBox
    {
        public void ShowCHM()
        {
            MyForm form1 = new MyForm();            
            form1.Show();
            MessageBox.Show("ABCD", "Caption is",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information,
                  MessageBoxDefaultButton.Button2,
                  0, @"S:\Product\Documentation\Help.chm",
                  HelpNavigator.TopicId, "34049");
        }
    }
    public class MyForm : Form
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0053) //WM_HELP 
            {
                System.Diagnostics.Debug.WriteLine("WM_HELP");
                //return;  //if don't handle the WM_HELP message, the CHM will NOT be launched
            }
            base.WndProc(ref m);
        }
    }
   
