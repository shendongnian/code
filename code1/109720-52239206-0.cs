    private Point GetCaretPosition()
    {
        Point result = TextBox.GetPositionFromCharIndex(TextBox.SelectionStart);
        if (result.X == 0 && TextBox.Text.Length > 0)
        {
            result = TextBox.GetPositionFromCharIndex(TextBox.Text.Length - 1);
            int s = result.X / TextBox.Text.Length;
            result.X = (int)(result.X + (s * 1.3));
        }
        return result;
    }
