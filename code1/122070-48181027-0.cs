       for (int i = 0; i < listBox1.Items.Count; i++)
        {
            if (textBox1.Text == listBox1.Items[i].ToString())
            {
                jeElement = true;
                break;
            }
        }
        if (jeElement)
        {
            label1.Text = "je element";
        }
        else
        {
            label1.Text = "ni element";
        }
        textBox1.ResetText();
        textBox1.Focus();
    }
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Alt == true && e.KeyCode == Keys.A)
        {
            buttonCheck.PerformClick();
        }
    }
}
