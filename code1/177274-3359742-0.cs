           //In Parent form
            protected override void OnMdiChildActivate(EventArgs e)
            {
                base.OnMdiChildActivate(e); //REQUIRED
                HandleChildMerge(); //Handle merging
            }
          
    
            private void HandleChildMerge()
            {
                ToolStripManager.RevertMerge(tsParent);
                IChildForm ChildForm = ActiveMdiChild as IChildForm;
                if (ChildForm != null)
                {
                    ToolStripManager.Merge(ChildForm.ChildToolStrip, tsParent);
                }
            }
       public partial class frmChild : Form, IChildForm
       {...}
       interface IChildForm
        {
            ToolStrip ChildToolStrip { get; set; }
        }
