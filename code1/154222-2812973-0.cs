     [DllImport("user32.dll")] // import lockwindow to remove flashing
        public static extern bool LockWindowUpdate(IntPtr hWndLock);
     
     public void Markup(RichTextBox RTB)
        {
            try
            {
                int selectionstart = richTextBox1.SelectionStart;
                Point pos = richTextBox1.Location;
                richTextBox1.Focus();
                int topIndex = richTextBox1.GetCharIndexFromPosition(new Point(1, 1));
                //int topIndex = richTextBox1.GetCharIndexFromPosition(point);
                int bottomIndex = richTextBox1.GetCharIndexFromPosition(new Point(1, richTextBox1.Height - 1));
                int topLine = richTextBox1.GetLineFromCharIndex(topIndex);
                int bottomLine = richTextBox1.GetLineFromCharIndex(bottomIndex);
                int start = richTextBox1.GetFirstCharIndexFromLine(topLine);
                int end = richTextBox1.GetFirstCharIndexFromLine(bottomLine);
                int numLinesDisplayed = (bottomLine - topLine) + 2;
                richTextBox1.Focus();
                richTextBox1.Select(start, end);
                Regex rex = new Regex("<html>|</html>|<head.*?>|</head>|<body.*?>|</body>|<div.*?>|</div>|<span.*?>|</span>|<title.*?>|</title>|<style.*?>|</style>|<script.*?>|</script>|<link.*?/>|<meta.*?/>|<base.*?/>|<center.*?>|</center>");
                foreach (Match m in rex.Matches(richTextBox1.SelectedText))
                {
                    richTextBox1.Select(m.Index + start, m.Value.Length);
                    richTextBox1.SelectionColor = Color.Blue;
                    richTextBox1.Select(selectionstart, -1);
                    richTextBox1.SelectionColor = Color.Black;
                }
                richTextBox1.DeselectAll();
                richTextBox1.SelectionStart = selectionstart;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        
        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            
                try
                {
                    
                    LockWindowUpdate(richTextBox1.Handle);//Stop flashing
                    Markup(richTextBox1);
                    Elements(richTextBox1);
                    FormsTabels(richTextBox1);
                    Attributes(richTextBox1);
                    Comments(richTextBox1);
                }
                finally { LockWindowUpdate(IntPtr.Zero); }
            
            
        }
