     public partial class Form1 : Form
     {
          CheckedListBox CheckedListBox1 = null;
          Button button12 = null;
          private void button10_Click(object sender, EventArgs e) 
          {
            CheckedListBox1 = new CheckedListBox();
            CheckedListBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
            CheckedListBox1.ItemHeight = 16;
            CheckedListBox1.Location = new System.Drawing.Point(12, 313);
            CheckedListBox1.Name = "CheckedListBox1";
            CheckedListBox1.Size = new System.Drawing.Size(168, 244);
            CheckedListBox1.TabIndex = 0;
            Controls.Add(CheckedListBox1);
            button12 = new Button();
            button12.Location = new Point(900, 500);
            button12.Size = new Size(75, 23);
            button12.Click += new System.EventHandler(button12_Click);
            button12.Name = "button12";
            button12.Text = "Toggle All";
            Controls.Add(button12);
        }
 
        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (CheckedListBox1.Items.Count - 1); i++)
            {
                if (CheckedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    CheckedListBox1.SetItemCheckState(i, CheckState.Indeterminate);
                }
                else if (CheckedListBox1.GetItemCheckState(i) == CheckState.Indeterminate)
                {
                    CheckedListBox1.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }
     }
