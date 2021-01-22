    Rectangle pRect = new Rectangle(10, 10, 20, 20);
    private void rect_Click(object sender, EventArgs e)
    {
      ControlPaint.DrawReversibleFrame(pRect, this.BackColor, FrameStyle.Thick);
    }
