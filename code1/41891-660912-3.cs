    static void DoForEachControl(Control control, Action<Control> f)
    {
      control.Controls.ForEach<Control>(c =>
                                          {
                                            f(c);
                                            DoForEachControl(c, f);
                                          });
    }
 
