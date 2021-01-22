    using System;
    using System.Windows.Forms;
    
    class ValueBox : TextBox {
      public event EventHandler BadValue;
      public event EventHandler ValueChanged;
    
      private int mValue;
      public int Value {
        get { return mValue; }
        set {
          if (value != mValue) {
            mValue = value;
            OnValueChanged(EventArgs.Empty);
            base.Text = mValue.ToString();
          }
        }
      }
      protected void OnValueChanged(EventArgs e) {
        EventHandler handler = ValueChanged;
        if (handler != null) handler(this, e);
      }
      protected void OnBadValue(EventArgs e) {
        EventHandler handler = BadValue;
        if (handler != null) handler(this, e);
      }
      protected override void OnHandleCreated(EventArgs e) {
        base.OnHandleCreated(e);
        base.Text = mValue.ToString();
      }
      protected override void OnValidating(System.ComponentModel.CancelEventArgs e) {
        int value;
        if (!int.TryParse(base.Text, out value)) {
          SelectionStart = 0;
          SelectionLength = base.Text.Length;
          e.Cancel = true;
          OnBadValue(EventArgs.Empty);
        }
        else base.OnValidating(e);
      }
    }
