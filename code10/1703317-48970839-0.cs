    public string padString(string s, Graphics g, Font f, float desiredWidth, float spaceWidth)
    {
        float orig = g.MeasureString(s, f).Width;
        int spaceCount = (int)Math.Max(0, (desiredWidth - orig) / spaceWidth);
        return s + new string(' ', spaceCount) + '\t';
    }
    private void button1_Click(object sender, EventArgs e)
    {
        using (Graphics g = CreateGraphics())
        {
            Font f = textBox1.Font;
            float tabWidth = g.MeasureString("x\t\t\tx", f).Width - g.MeasureString("x\t\tx", f).Width;
            float spaceWidth = g.MeasureString("x   x", f).Width - g.MeasureString("x  x", f).Width;
            float dw = tabWidth * 5.5f; // half of the tab is on purpose
            String s1 = String.Format("{0}{1,8}", padString("some string", g, f, dw, spaceWidth), "$20.00");
            String s2 = String.Format("{0}{1,8}", padString("些字符串些字符串些字符串些字符串", g, f, dw, spaceWidth), "$20.00");
            String s3 = String.Format("{0}{1,8}", padString("些", g, f, dw, spaceWidth), "$20.00");
            String s4 = String.Format("{0}{1,8}", padString("a", g, f, dw, spaceWidth), "$20.00");
            textBox1.AppendText(s1 + "\n");
            textBox1.AppendText(s2 + "\n");
            textBox1.AppendText(s3 + "\n");
            textBox1.AppendText(s4 + "\n");
        }
    }
