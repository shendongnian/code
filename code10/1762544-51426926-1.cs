    private void textEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            var editor = (DevExpress.XtraEditors.TextEdit)sender;
            if (e.NewValue != null)
            {
                var s = (string)e.NewValue;
                if (string.IsNullOrWhiteSpace(s.TrimStart('0')) == false)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        editor.Text = s.TrimStart('0').PadLeft(6, '0');
                        editor.SelectionStart = editor.Text.Length;
                }));
                }
            }
        }
