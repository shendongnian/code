            private void textBox1_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Oemcomma) //we will perform this on every ',' press
                {
                    flayoutCustomControlContainer.Controls.Remove(textBox1);
    
                    TagControl tag = new TagControl(); //creating new Tag control
                    tag.lblTagName.Text = textBox1.Text.TrimEnd(",".ToCharArray());
                    tag.Remvoed += tag_Remvoed; //subscribing "Removed" event of Tag
    
                    tag.Width = tag.lblTagName.Width + 50;
                    tag.Height = tag.lblTagName.Height + 5;
    
                    flayoutCustomControlContainer.Controls.Add(tag);
    
                    textBox1.Text = "";
    
                    flayoutCustomControlContainer.Controls.Add(textBox1);
    
                    textBox1.Focus();
                }
            }
    
    void tag_Remvoed(object sender, EventArgs e)
    {
        this.flayoutCustomControlContainer.Controls.Remove((Control)sender);
        textBox1.Focus();
    }
