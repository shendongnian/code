    public class MyForm : Form
    {
       MouseMessageFilter msgFilter;
    
       public MyForm()
       {...
           msgFilter = new MouseMessageFilter();
           msgFilter.MouseDown += new MouseMessageFilter.CancelMouseEventHandler(msgFilter_MouseDown);
           msgFilter.MouseMove += new MouseMessageFilter.CancelMouseEventHandler(msgFilter_MouseMove);
        }
    
        private void msgFilter_MouseMove(object source, MouseMessageFilter.CancelMouseEventArgs e)
        {
            if (CheckSomething(e.Control)
                e.Cancel = true;
        }   
    }
