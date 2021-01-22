    textBox.BackColor = System.Drawing.SystemColors.Control;
    textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
    textBox.ReadOnly = true;
    textBox.Text = "This is selectable text";
    textBox.MouseUp += new MouseEventHandler(
                              delegate(object sender, MouseEventArgs e)
                                 { HideCaret((sender as Control).Handle); });
    [DllImport("User32.dll")]
    static extern Boolean HideCaret(IntPtr hWnd);
