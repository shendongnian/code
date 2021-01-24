     public void ChangeLabel()
     {
         status_label.Text = "HeyHey";
         MessageBox.Show(status_label.Text);
         // MessageBox : HeyHey, but on UI showing the old value.
     }
     // MyForm open
     private void button_Click(object sender, EventArgs e)
     {
         MyForm mf = new MyForm(this);
         if (!mf.Visible)
         {
              mf.Show();
         }
         else
         {
            mf.BringToFront();
         }
     }
