    private void button1_Click(object sender, EventArgs e)
    {
      //force execution on another thread
      new Thread(updateLabelThreaded).Start();
    }
    private void button2_Click(object sender, EventArgs e)
    {
      //force execution on another thread
       new Thread(updateLabelReflect).Start();
    }
        
    private void updateLabelThreaded()
    {
        if (!label1.InvokeRequired)
        {
          //if we are on the correct thread, do a trivial update
           label1.Text = "something";
        }
        else
        {
           //else invoke the same method, on the UI thread
            Invoke(new Action(updateLabelThreaded), null);
        }
    }
     private void updateLabelReflect()
     {
         Control ctrl = label2;
         PropertyInfo pi = typeof (Label).GetProperty("InvokeRequired");
         bool shouldInvoke = (bool) pi.GetValue(ctrl, null);
         if (!shouldInvoke)
         {
            //if we are on the correct thread, reflect whatever is neccesary - business as usual
            PropertyInfo txtProp = typeof (Label).GetProperty("Text");
            txtProp.SetValue(ctrl, "Something 2", null);
         }
         else
         {
           //else invoke the same method, on the UI thread
           Invoke(new Action(updateLabelReflect), null);
         }
       }
