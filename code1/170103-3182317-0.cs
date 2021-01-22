        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) {
            this.BeginInvoke(new MethodInvoker(evalList), null);
        }
        private void evalList() {
            bool any = false;
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix) {
                if (checkedListBox1.GetItemChecked(ix)) {
                    any = true;
                    break;
                }
            }
            btnInstall.Enabled = any;
        }
