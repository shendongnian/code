        public void MDIChildClosed()
        {
            if (this.MdiChildren.Length == 1)
            {
                this.Controls.Remove(theMdiClient);
                panel1.Visible = true; 
            }
        }
