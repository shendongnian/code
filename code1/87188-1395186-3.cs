       public class ComboBoxEditThreadSafe : DevExpress.XtraEditors.ComboBoxEdit    
    {       
       public override object EditValue        
       {            
           get {  return base.EditValue;   }            
           set { SetValue(value); }
       }
       
       private void SetValue(object value)
       {
           if (this.InvokeRequired)
               this.BeginInvoke(
                   new Action<object>(SetValue),  // calls itself, but on correct thread
                   new object[] { value });
           else                
                  base.editValue = value;  
            
       }
   }
