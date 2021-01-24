        private void textEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            const int MaxLength = 6;
            var editor = (DevExpress.XtraEditors.TextEdit)sender;
            if (e.NewValue != null)
            {
                var s = (string)e.NewValue;
                s = s.TrimStart('0');
                if (string.IsNullOrWhiteSpace(s) == false)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        editor.Text = s.Substring(0, Math.Min(s.Length, MaxLength)).PadLeft(MaxLength, '0');
                        editor.SelectionStart = MaxLength;
                    }));
                }
            }
        }
