        void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (IsToolbarButtonNeededForThisForm(child))
                {
                    toolButton.Enabled = true;
                    break;
                }
            }
            toolButton.Enabled = false;
