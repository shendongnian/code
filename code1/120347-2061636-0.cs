    Size mOldSize;
    private void glControl_Resize(object sender, EventArgs e) {
      if (mOldSize != Size.Empty && mOldSize != glControl.Size) {
        // do something...
      }
      mOldSize = glControl.Size;
    }
