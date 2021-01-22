    private void SetProgressBarValue(int progressPercentage)
    {
        InvokeIfNecessary(
            this, () =>
                  {
                      var value = progressPercentage;
                      if (progressPercentage < 0)
                      {
                          value = 0;
                      }
                      else if (progressPercentage > 100)
                      {
                          value = 100;
                      }
                      InvokeIfNecessary(
                          statusProgressBar.GetCurrentParent(),
                          () => statusProgressBar.Value = value);
                      InvokeIfNecessary(
                          statusLabel.GetCurrentParent(),
                          () =>
                          statusLabel.Text = string.Format("{0}%", value));
                  });
    }
    private static void InvokeIfNecessary(Control control, Action setValue)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(setValue);
        }
        else
        {
            setValue();
        }
    }
