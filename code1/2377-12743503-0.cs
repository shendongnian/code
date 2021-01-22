    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    namespace CrossThreadCalls
    {
      public static class clsCrossThreadCalls
      {
        private delegate void SetAnyPropertyCallBack(Control c, string Property, object Value);
        public static void SetAnyProperty(Control c, string Property, object Value)
        {
          if (c.GetType().GetProperty(Property) != null)
          {
            //The given property exists
            if (c.InvokeRequired)
            {
              SetAnyPropertyCallBack d = new SetAnyPropertyCallBack(SetAnyProperty);
              c.BeginInvoke(d, c, Property, Value);
            }
            else
            {
              c.GetType().GetProperty(Property).SetValue(c, Value, null);
            }
          }
        }
        private delegate void SetTextPropertyCallBack(Control c, string Value);
        public static void SetTextProperty(Control c, string Value)
        {
          if (c.InvokeRequired)
          {
            SetTextPropertyCallBack d = new SetTextPropertyCallBack(SetTextProperty);
            c.BeginInvoke(d, c, Value);
          }
          else
          {
            c.Text = Value;
          }
        }
      }
    
