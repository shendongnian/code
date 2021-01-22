    class MyTextBox : TextBox {
      Color mBackColor;
      protected override void OnEnter(EventArgs e) {
        mBackColor = base.BackColor;
        base.BackColor = Color.AliceBlue;
        base.OnEnter(e);
      }
      protected override void OnLeave(EventArgs e) {
        base.BackColor = mBackColor;
        base.OnLeave(e);
      }
    }
