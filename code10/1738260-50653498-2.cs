            string msg = "";
            foreach (string s in ss.GetPropertyNames(""))
            {
                msg += s + "\r\n";
            }
            MessageBox.Show(msg);
