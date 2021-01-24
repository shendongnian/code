    int pos = 0;
                    int len = txtNumber.Text.Length;
                    string s = txtNumber.Text;
    
                    while (true)
                    {
                        if (pos >= len) break;
                        if (space == s[pos] && (((pos + 1) % 11) != 0 || pos + 1 == s.Length))
                        {
                            s.Remove(pos, pos + 1);
                            txtNumber.Select(txtNumber.Text.Length, 1);
                            txtNumber.ScrollToEnd();
                            txtNumber.Focus();
                        }
                        else
                        {
                            pos++;
                        }
                    }
                    pos = 10;
                    while (true)
                    {
                        if (pos >= len) break;
                        char c = s[pos];
                        if (char.IsDigit(c))
                        {
                            s = s.Insert(pos, "" + space);
                            txtNumber.Text = s;
                        }
                        pos += 11;
                        txtNumber.Select(txtNumber.Text.Length, 1);
                        txtNumber.ScrollToEnd();
                        txtNumber.Focus();
                    }
