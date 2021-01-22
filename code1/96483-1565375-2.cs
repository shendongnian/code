    using (Graphics g = this.CreateGraphics())
    {
        string s = "";
        SizeF size;
        int numberOfCharacters = 0;
        float maxWidth = 50;
        while (true)
        {
            s += "a";
            size = g.MeasureString(s, this.Font);
            if (size.Width > maxWidth)
            {
                break;
            }
            numberOfCharacters++;
        }
        // numberOfCharacters will now contain your max string length
    }
