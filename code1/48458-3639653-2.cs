    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    
    namespace System.Windows.Forms
    {
      class MyDataGridView : DataGridView
      {
        protected override bool ProcessDialogKey(Keys keyData)
        {
          if (keyData == Keys.Enter || keyData == Keys.Tab)
          {
            MyProcessTabKey(Keys.Tab);
            return true;
          }
          return base.ProcessDialogKey(keyData);
        }
    
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
          if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
          {
            MyProcessTabKey(Keys.Tab);
            return true;
          }
          return base.ProcessDataGridViewKey(e);
        }
    
        protected bool MyProcessTabKey(Keys keyData)
        {
          bool retValue = base.ProcessTabKey(Keys.Tab);
          while (this.CurrentCell.ReadOnly)
          {
            retValue = base.ProcessTabKey(Keys.Tab);
          }
          return retValue;
        }
      }
    }
