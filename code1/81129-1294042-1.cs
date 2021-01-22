    private void TreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
    {
        string regex = @"^.*\s+\[\d+\]$";
        if (Regex.IsMatch(e.Node.Text, regex, RegexOptions.Compiled))
        {
            string[] parts = e.Node.Text.Split(' ');
            if (parts.Length > 1)
            {
                string count = parts[parts.Length - 1];
                string text = " " + string.Join(" ", parts, 0, parts.Length - 1);
                Font normalFont = e.Node.TreeView.Font;
    
                float textWidth = e.Graphics.MeasureString(text, normalFont).Width;
                e.Graphics.DrawString(text, 
                                      normalFont, 
                                      SystemBrushes.WindowText, 
                                      e.Bounds);
    
                using (Font boldFont = new Font(normalFont, FontStyle.Bold))
                {
                    e.Graphics.DrawString(count, 
                                          boldFont, 
                                          SystemBrushes.WindowText,
                                          e.Bounds.Left + textWidth, 
                                          e.Bounds.Top); 
                }
            }
        }
        else
        {
            e.DrawDefault = true;
        }
    }
