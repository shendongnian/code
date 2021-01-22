        Dictionary<int, Form2> instances = new Dictionary<int, Form2>();
        public void OpenForm(int id) {
            if (instances.ContainsKey(id)) {
                var frm = instances[id];
                frm.WindowState = FormWindowState.Normal;
                frm.Focus();
            }
            else {
                var frm = new Form2(id);
                instances.Add(id, frm);
                frm.FormClosed += delegate { instances.Remove(id); };
                frm.Show();
            }
        }
