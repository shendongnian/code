    private Size GetPreferredSize(String text, Font font, StringFormat format)
    {
        Graphics graphics = this.CreateGraphics();
        if (format == null)
        {
            format = new StringFormat();
        }
        SizeF textSize = SizeF.Empty;
        // The minimum width allowed for the rectangle.
        double minWidth = 100;
        // The ratio for the height compared to the width.
        double heightRatio = 0.61803399; // Gloden ratio to make it look pretty :)
        // The amount to in/decrement for width.
        double step = 100;
        // The new width to be set.
        double newWidth = minWidth;
        // Find the largest width that the text fits into.
        while (true)
        {
            textSize = graphics.MeasureString(text, font, (int)Math.Round(newWidth), format);
            if (textSize.Height <= newWidth * heightRatio)
            {
                break;
            }
            newWidth += step;
        }
        step /= 2;
        // Continuously divide the step to adjust the rectangle.
        while (true)
        {
            // Ensure step.
            if (step < 1)
            {
                break;
            }
            // Ensure minimum width.
            if (newWidth - step < minWidth)
            {
                break;
            }
            // Try to subract the step from the width.
            while (true)
            {
                // Measure the text.
                textSize = graphics.MeasureString(text, font, (int)Math.Round(newWidth - step), format);
                // If the text height is going to be less than the new height, decrease the new width.
                // Otherwise, break to the next lowest step.
                if (textSize.Height < (newWidth - step) * heightRatio)
                {
                    newWidth -= step;
                }
                else
                {
                    break;
                }
            }
            step /= 2;
        }
        double width = newWidth;
        double height = width * heightRatio;
        return new Size((int)Math.Ceiling(width), (int)Math.Ceiling(height));
    }
