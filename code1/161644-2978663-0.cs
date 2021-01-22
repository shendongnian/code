                public MainForm()
                {
                  ...code
                  Resize += MainForm_Resize;
                  notifyIcon.DoubleClick += NotifyIconDoubleClick;
                  WindowState = FormWindowState.Minimized;
                  Hide();
                }
                private void MainForm_Resize(object sender, EventArgs e)
                {
                  if (FormWindowState.Minimized == WindowState)
                     Hide();
                }
                private void NotifyIconDoubleClick(object sender, EventArgs e)
                {
                   Show();
                   try
                   {
                      WindowState = FormWindowState.Normal;
                      ...more code for other stuff
                    }catch(yadda yadda)
                      ...code
                    }
                 }
