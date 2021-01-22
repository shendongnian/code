class DataGridViewCheckBoxColumnHeaderCell : DataGridViewColumnHeaderCell
{
    private Bitmap buffer;
    private CheckBox checkBox;
    private Rectangle checkBoxBounds;
    public DataGridViewCheckBoxColumnHeaderCell()
    {
        this.checkBox = new CheckBox();
    }
    public event EventHandler CheckedChanged;
    public bool Checked
    {
        get 
        { 
            return this.checkBox.Checked; 
        }
        set
        {
            if (!this.Checked == value)
            {
                this.checkBox.Checked = value;
                if (this.buffer != null)
                {
                    this.buffer.Dispose();
                    this.buffer = null;
                }
                this.OnCheckedChanged(EventArgs.Empty);
                if (this.DataGridView != null)
                {
                    this.DataGridView.Refresh();
                }
            }
        }
    }
    protected override void Paint(
        Graphics graphics, 
        Rectangle clipBounds, 
        Rectangle cellBounds, 
        int rowIndex, 
        DataGridViewElementStates dataGridViewElementState, 
        object value, 
        object formattedValue, 
        string errorText, 
        DataGridViewCellStyle cellStyle, 
        DataGridViewAdvancedBorderStyle advancedBorderStyle, 
        DataGridViewPaintParts paintParts)
    {
        // Passing String.Empty in place of 
        // value and formattedValue prevents 
        // this header cell from having text.
        base.Paint(
            graphics, 
            clipBounds, 
            cellBounds, 
            rowIndex, 
            dataGridViewElementState, 
            String.Empty, 
            String.Empty, 
            errorText, 
            cellStyle, 
            advancedBorderStyle, 
            paintParts);
        if (this.buffer == null 
            || cellBounds.Width != this.buffer.Width
            || cellBounds.Height != this.buffer.Height)
        {
            this.UpdateBuffer(cellBounds.Size);
        }
        graphics.DrawImage(this.buffer, cellBounds.Location);
    }
    protected override Size GetPreferredSize(
        Graphics graphics, 
        DataGridViewCellStyle cellStyle, 
        int rowIndex, 
        Size constraintSize)
    {
        return this.checkBox.GetPreferredSize(constraintSize);
    }
    protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left 
            && this.checkBoxBounds.Contains(e.Location))
        {
            this.Checked = !this.Checked;
        }
        base.OnMouseClick(e);
    }
    private void UpdateBuffer(Size size)
    {
        Bitmap updatedBuffer = new Bitmap(size.Width, size.Height);
        this.checkBox.Size = size;
        if (this.checkBox.Size.Width > 0 && this.checkBox.Size.Height > 0)
        {
            Bitmap renderedCheckbox = new Bitmap(
                this.checkBox.Width, 
                this.checkBox.Height);
            this.checkBox.DrawToBitmap(
                renderedCheckbox, 
                new Rectangle(new Point(), this.checkBox.Size));
            MakeTransparent(renderedCheckbox, this.checkBox.BackColor);
            Bitmap croppedRenderedCheckbox = AutoCrop(
                renderedCheckbox, 
                Color.Transparent);
            // TODO implement alignment, right now it is always
            // MiddleCenter regardless of this.Style.Alignment
            this.checkBox.Location = new Point(
                (updatedBuffer.Width - croppedRenderedCheckbox.Width) / 2, 
                (updatedBuffer.Height - croppedRenderedCheckbox.Height) / 2);
            Graphics updatedBufferGraphics = Graphics.FromImage(updatedBuffer);
            updatedBufferGraphics.DrawImage(
                croppedRenderedCheckbox, 
                this.checkBox.Location);
            this.checkBoxBounds = new Rectangle(
                this.checkBox.Location, 
                croppedRenderedCheckbox.Size);
            renderedCheckbox.Dispose();
            croppedRenderedCheckbox.Dispose();
        }
        if (this.buffer != null)
        {
            this.buffer.Dispose();
        }
        this.buffer = updatedBuffer;
    }
    protected virtual void OnCheckedChanged(EventArgs e)
    {
        EventHandler handler = this.CheckedChanged;
        if (handler != null)
        {
            handler(this, e);
        }
    }
    // The methods below are helper methods for manipulating Bitmaps
    private static void MakeTransparent(Bitmap bitmap, Color transparencyMask)
    {
        int transparencyMaskArgb = transparencyMask.ToArgb();
        int transparentArgb = Color.Transparent.ToArgb();
        List<int> deadColumns = new List<int>();
        for (int x = 0; x < bitmap.Width; x++)
        {
            if (deadColumns.Count == bitmap.Height)
            {
                break;
            }
            for (int y = 0; y < bitmap.Height; y++)
            {
                if (deadColumns.Contains(y))
                {
                    continue;
                }
                int pixel = bitmap.GetPixel(x, y).ToArgb();
                if (pixel == transparencyMaskArgb)
                {
                    bitmap.SetPixel(x, y, Color.Transparent);
                }
                else if (pixel != transparentArgb)
                {
                    deadColumns.Add(y);
                    break;
                }
            }
        }
        deadColumns.Clear();
        for (int x = bitmap.Width - 1; x >= 0; x--)
        {
            if (deadColumns.Count == bitmap.Height)
            {
                break;
            }
            for (int y = bitmap.Height - 1; y >= 0; y--)
            {
                if (deadColumns.Contains(y))
                {
                    continue;
                }
                int pixel = bitmap.GetPixel(x, y).ToArgb();
                if (pixel == transparencyMaskArgb)
                {
                    bitmap.SetPixel(x, y, Color.Transparent);
                }
                else if (pixel != transparentArgb)
                {
                    deadColumns.Add(y);
                    break;
                }
            }
        }
    }
    public static Bitmap AutoCrop(Bitmap bitmap, Color backgroundColor)
    {
        Size croppedSize = bitmap.Size;
        Point cropOrigin = new Point();
        int backgroundColorToArgb = backgroundColor.ToArgb();
        for (int x = bitmap.Width - 1; x >= 0; x--)
        {
            bool allPixelsAreBackgroundColor = true;
            for (int y = bitmap.Height - 1; y >= 0; y--)
            {
                if (bitmap.GetPixel(x, y).ToArgb() != backgroundColorToArgb)
                {
                    allPixelsAreBackgroundColor = false;
                    break;
                }
            }
            if (allPixelsAreBackgroundColor)
            {
                croppedSize.Width--;
            }
            else
            {
                break;
            }
        }
        for (int y = bitmap.Height - 1; y >= 0; y--)
        {
            bool allPixelsAreBackgroundColor = true;
            for (int x = bitmap.Width - 1; x >= 0; x--)
            {
                if (bitmap.GetPixel(x, y).ToArgb() != backgroundColorToArgb)
                {
                    allPixelsAreBackgroundColor = false;
                    break;
                }
            }
            if (allPixelsAreBackgroundColor)
            {
                croppedSize.Height--;
            }
            else
            {
                break;
            }
        }
        for (int x = 0; x < croppedSize.Width; x++)
        {
            bool allPixelsAreBackgroundColor = true;
            for (int y = 0; y < croppedSize.Height; y++)
            {
                if (bitmap.GetPixel(x, y).ToArgb() != backgroundColorToArgb)
                {
                    allPixelsAreBackgroundColor = false;
                    break;
                }
            }
            if (allPixelsAreBackgroundColor)
            {
                cropOrigin.X++;
                croppedSize.Width--;
            }
            else
            {
                break;
            }
        }
        for (int y = 0; y < croppedSize.Height; y++)
        {
            bool allPixelsAreBackgroundColor = true;
            for (int x = 0; x < croppedSize.Width; x++)
            {
                if (bitmap.GetPixel(x, y).ToArgb() != backgroundColorToArgb)
                {
                    allPixelsAreBackgroundColor = false;
                    break;
                }
            }
            if (allPixelsAreBackgroundColor)
            {
                cropOrigin.Y++;
                croppedSize.Height--;
            }
            else
            {
                break;
            }
        }
        return GetSection(bitmap, new Rectangle(cropOrigin, croppedSize));
    }
    public static Bitmap GetSection(Bitmap bitmap, Rectangle section)
    {
        if (section.Width == 0 || section.Height == 0)
        {
            return new Bitmap(1, 1);
        }
        Bitmap bitmapSection = new Bitmap(section.Width, section.Height);
        for (int x = 0; x < section.Width; x++)
        {
            for (int y = 0; y < section.Height; y++)
            {
                int xWhole = x + section.X;
                int yWhole = y + section.Y;
                if (yWhole < bitmap.Height && yWhole >= 0 && xWhole < bitmap.Width && xWhole >= 0)
                {
                    bitmapSection.SetPixel(x, y, bitmap.GetPixel(xWhole, yWhole));
                }
                else
                {
                    bitmapSection.SetPixel(x, y, Color.Transparent);
                }
            }
        }
        return bitmapSection;
    }
}
