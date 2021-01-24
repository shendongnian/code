            private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            TabPage a;
            a=(TabPage)(this.Parent);
            TabControl b;
            b = (System.Windows.Forms.TabControl)a.Parent;
            b.TabPages.Remove(a);
        }
