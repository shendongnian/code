    public void CheckUnusedTabs(string strTabToRemove)
    { 
        if (TaskBarRef.tabControl1.InvokeRequired)
        {
            TaskBarRef.tabControl1.Invoke(new Action<string>(CheckUnusedTabs), strTabToRemove);
            return;
        }      
  
        TabPage tp = TaskBarRef.tabControl1.TabPages[strTabToRemove];
        tp.Controls.Remove(this);
        TaskBarRef.tabControl1.TabPages.Remove(tp);
    }
