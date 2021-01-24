    // ThisAddIn.cs
     
    namespace TaskPaneWorkaround
    {
        public partial class ThisAddIn
        {
            private MyUserControl myUserControl1;
            private Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;
     
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                myUserControl1 = new MyUserControl();
                myCustomTaskPane = this.CustomTaskPanes.Add(myUserControl1, "My Task Pane");
                myCustomTaskPane.Visible = true;
            }
     
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
     
            #region VSTO generated code
     
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InternalStartup()
            {
                this.Startup += new System.EventHandler(ThisAddIn_Startup);
                this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            }
            
            #endregion
        }
    }
     
    // MyUserControl.cs
     
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
     
    namespace TaskPaneWorkaround
    {
        public partial class MyUserControl: UserControl
        {
            bool isformdisplayed = false;
            WorkaroundForm workaroundForm;
     
            [DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
     
            public MyUserControl()
            {
                this.SuspendLayout();
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.Name = "MyUserControl";
                this.Paint += new System.Windows.Forms.PaintEventHandler(this.MyUserControl_Paint);
                this.Resize += new System.EventHandler(this.MyUserControl_Resize);
                this.ResumeLayout(false);
     
                this.Paint += MyUserControl_Paint;
                this.Resize += MyUserControl_Resize;
            }
     
            private void MyUserControl_Load(object sender, System.EventArgs e)
            {
               this.Paint += MyUserControl_Paint;
            }
     
            private void MyUserControl_Paint(object sender, PaintEventArgs e)
            {
                if (!isformdisplayed)
                {
                    this.SuspendLayout();
                    workaroundForm = new WorkaroundForm();
                    SetParent(workaroundForm.Handle, this.Handle);
                    workaroundForm.Dock = DockStyle.Fill;
                    workaroundForm.Width = Width;
                    workaroundForm.Height = Height;
                    workaroundForm.Show();
                    isformdisplayed = true;
                    this.ResumeLayout();
                }
            }
     
            private void MyUserControl_Resize(object sender, EventArgs e)
            {
                if (isformdisplayed)
                {
                    workaroundForm.Width = this.Width;
                    workaroundForm.Height = this.Height;
                }
            }
        }
    }
     
    //WorkaroundForm.cs
     
    using System;
    using System.Drawing;
    using System.Windows.Forms;
     
    namespace TaskPaneWorkaround
    {
        public partial class WorkaroundForm: Form
        {
            public WorkaroundForm()
            {
                this.SuspendLayout();
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(509, 602);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.WorkaroundForm_Load);
                this.ResumeLayout(false);
            }
            private void WorkaroundForm_Load(object sender, EventArgs e)
            {
                this.SuspendLayout();
                this.Location = new Point(0, 0);
                this.Dock = DockStyle.Fill;
                this.FormBorderStyle = FormBorderStyle.None;
                WebBrowser webBrowser = new WebBrowser();
                this.Controls.Add(webBrowser);
                webBrowser.Location = new Point(0, 0);
                webBrowser.Dock = DockStyle.Fill;
                this.ResumeLayout();
                webBrowser.Focus();
                webBrowser.Navigate(new System.Uri("https://bing.com"));
            }
        }
    }
