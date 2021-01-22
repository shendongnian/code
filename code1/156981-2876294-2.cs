    String s = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer bibendum pharetra quam, sit amet pellentesque orci porta malesuada. Sed vestibulum euismod velit, eget vulputate odio tempor sit amet. Pellentesque pretium congue erat, id vulputate augue consectetur vitae. Duis pharetra, metus malesuada cursus vehicula, lacus sem consequat metus, consectetur iaculis neque nunc id neque. Nunc in orci libero.";
    Font f = new System.Drawing.Font("Arial", 11);
    SizeF textSize = SizeF.Empty;
    double heightRatio = 0.61803399; // Gloden ratio.
    double minWidth = 200;
    double step = 100;
    double newWidth = minWidth;
    while (true)
    {
        textSize = e.Graphics.MeasureString(s, f, (int)Math.Ceiling(newWidth));
        if (textSize.Height <= newWidth * heightRatio)
        {
            break;
        }
        newWidth += step;
    }
    step /= 2;
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
        while (true)
        {
                    
            // Measure the text.
            textSize = e.Graphics.MeasureString(s, f, (int)Math.Ceiling(newWidth - step));
            // If the text height is going to be less than the new height, decrease the new width.
            // Otherwise, break to the next lowest step.
            if (textSize.Height <= (newWidth - step) * heightRatio)
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
