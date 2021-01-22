        public class ShowProgress
        {
            static private System.Drawing.Point point;
            static private ProcessingRequest p;
            static public void ShowProgressForm(System.Drawing.Point myPoint)
            {
                point = myPoint;
                Thread t = new Thread(new ThreadStart(ShowProgress.ShowForm));
                t.IsBackground = true;
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            static private void ShowForm()
            {
                p = new ProcessingRequest();
                p.StartPosition = FormStartPosition.Manual;
                p.Location = point;
                p.TopMost = true;
                Application.Run(p);
            }
            static public void CloseForm()
            {
                p.Invoke(new CloseDelegate(ShowProgress.CloseFormInternal));
            }
            static private void CloseFormInternal()
            {
                p.Close();
            }
        }
        public delegate void CloseDelegate();
