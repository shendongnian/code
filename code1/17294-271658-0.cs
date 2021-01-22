    double MeasureStringHeight (Graphics g, string s, Font f, int w) {
        double result = 0;
        int n = s.Length;
        int i = 0;
        while (i < n) {
            StringBuilder line = new StringBuilder();
            int iLineStart = i;
            int iSpace = -1;
            SizeF sLine = new SizeF(0, 0);
            while ((i < n) && (sLine.Width <= w)) {
                char ch = s[i];
                if ((ch == ' ') || (ch == '-')) {
                    iSpace = i;
                }
                line.Append(ch);
                sLine = g.MeasureString(line.ToString(), f);
                i++;
            }
            if (sLine.Width > w) {
                if (iSpace >= 0) {
                    i = iSpace + 1;
                } else {
                    i--;
                }
                // Assert(w > largest ch in line)
            }
            result += sLine.Height;
        }
        return result;
    }
