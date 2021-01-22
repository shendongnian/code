    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    class MyForm : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MyForm());
        }
    
        ListBox listbox;
        TextBox textbox;
        CheckBox multi;
        public MyForm()
        {
            textbox = new TextBox { Dock = DockStyle.Top };
            List<string> strings = new List<string> { "abc", "abd", "abed", "ab" };
            listbox = new ListBox { Dock = DockStyle.Fill, DataSource = strings };
            textbox.KeyDown += textbox_KeyDown;
            Controls.Add(listbox);
            Controls.Add(textbox);
            listbox.SelectedIndexChanged += listbox_SelectedIndexChanged;
            listbox.SelectionMode = SelectionMode.MultiExtended;
            multi = new CheckBox { Text = "select multiple", Dock = DockStyle.Bottom };
            Controls.Add(multi);
        }
    
        void listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Text = Convert.ToString(listbox.SelectedItem);
        }
    
        void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string searchFor = textbox.Text;
                List<string> strings = (List<string>)listbox.DataSource;
                if (multi.Checked)
                {
                    for (int i = 0; i < strings.Count; i++)
                    {
                        listbox.SetSelected(i, strings[i].Contains(searchFor));
                    }
                }
                else
                {
                    listbox.ClearSelected();
                    listbox.SelectedIndex = strings.FindIndex(
                        s => s.Contains(searchFor));
                }
            }
        }
    }
