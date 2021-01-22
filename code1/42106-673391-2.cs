    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    class MyForm : Form {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run(new MyForm());
        }
        ComboBox encodings;
        TextBox view;
        Button load, next;
        byte[] data = null;
    
        void ShowData() {
            if (data != null && encodings.SelectedIndex >= 0) {
                try {
                    Encoding enc = Encoding.GetEncoding(
                        (string)encodings.SelectedValue);
                    view.Text = enc.GetString(data);
                } catch (Exception ex) {
                    view.Text = ex.ToString();
                }
            }
        }
        public MyForm() {
            load = new Button();
            load.Text = "Open...";
            load.Dock = DockStyle.Bottom;
            Controls.Add(load);
    
            next = new Button();
            next.Text = "Next...";
            next.Dock = DockStyle.Bottom;
            Controls.Add(next);
            
            view = new TextBox();
            view.ReadOnly = true;
            view.Dock = DockStyle.Fill;
            view.Multiline = true;
            Controls.Add(view);
    
            encodings = new ComboBox();
            encodings.Dock = DockStyle.Bottom;
            encodings.DropDownStyle = ComboBoxStyle.DropDown;
            encodings.DataSource = Encoding.GetEncodings();
            encodings.DisplayMember = "DisplayName";
            encodings.ValueMember = "Name";
            Controls.Add(encodings);
    
            next.Click += delegate { encodings.SelectedIndex++; };
    
            encodings.SelectedValueChanged += delegate { ShowData(); };
    
            load.Click += delegate {
                using (OpenFileDialog dlg = new OpenFileDialog()) {
                    if (dlg.ShowDialog(this)==DialogResult.OK) {
                        data = File.ReadAllBytes(dlg.FileName);
                        Text = dlg.FileName;
                        ShowData();
                    }
                }
            };
        }
    }
