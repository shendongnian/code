         private void MdiChild_Shown(object sender, EventArgs e)
         {
            //temporarily store the Mdiparent in a variable
            Form mdiparent = this.MdiParent;
            //set mdiparent to null
            this.MdiParent = null;
            //change the opacity
            for (double i = 0.01; i <= 1.00; i += 0.05)
            {
                if (this.Opacity <= 1.00)
                {
                    this.Opacity += i;
                    this.Refresh();
                    System.Threading.Thread.Sleep(100);
                }
            }
            //now reassign the mdiparent to the MdiChild
            this.MdiParent = mdiparent;
        }
