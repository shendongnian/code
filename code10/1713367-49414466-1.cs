    private void UpdateFont()
    {
        System.Drawing.FontStyle style = System.Drawing.FontStyle.Regular;
        if (checkBox1.Checked) style |= System.Drawing.FontStyle.Bold;
        if (checkBox2.Checked) style |= System.Drawing.FontStyle.Italic;
        if (checkBox3.Checked) style |= System.Drawing.FontStyle.Underline;
        textBox1.Font = new Font(textBox1.Font, style);
    }
