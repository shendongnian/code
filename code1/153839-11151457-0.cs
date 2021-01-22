    private void DrawCurvedText(Graphics graphics, string text, Point centre, float distanceFromCentreToBaseOfText, float radiansToTextCentre, Font font, Brush brush)
    {
        // Circumference for use later
        var circleCircumference = (float)(Math.PI * 2 * distanceFromCentreToBaseOfText);
        // Get the width of each character
        var characterWidths = GetCharacterWidths(graphics, text, font).ToArray();
        // The overall height of the string
        var characterHeight = graphics.MeasureString(text, font).Height;
        var textLength = characterWidths.Sum();
        // The string length above is the arc length we'll use for rendering the string. Work out the starting angle required to 
        // centre the text across the radiansToTextCentre.
        float fractionOfCircumference = textLength / circleCircumference;
        float currentCharacterRadians = radiansToTextCentre + (float)(Math.PI * fractionOfCircumference);
        for (int characterIndex = 0; characterIndex < text.Length; characterIndex++)
        {
            char @char = text[characterIndex];
            // Polar to cartesian
            float x = (float)(distanceFromCentreToBaseOfText * Math.Sin(currentCharacterRadians));
            float y = -(float)(distanceFromCentreToBaseOfText * Math.Cos(currentCharacterRadians));
            using (GraphicsPath characterPath = new GraphicsPath())
            {
                characterPath.AddString(@char.ToString(), font.FontFamily, (int)font.Style, font.Size, Point.Empty,
                                        StringFormat.GenericTypographic);
                var pathBounds = characterPath.GetBounds();
                // Transformation matrix to move the character to the correct location. 
                // Note that all actions on the Matrix class are prepended, so we apply them in reverse.
                var transform = new Matrix();
                // Translate to the final position
                transform.Translate(centre.X + x, centre.Y + y);
                // Rotate the character
                var rotationAngleDegrees = currentCharacterRadians * 180F / (float)Math.PI - 180F;
                transform.Rotate(rotationAngleDegrees);
                // Translate the character so the centre of its base is over the origin
                transform.Translate(-pathBounds.Width / 2F, -characterHeight);
                characterPath.Transform(transform);
                // Draw the character
                graphics.FillPath(brush, characterPath);
            }
            if (characterIndex != text.Length - 1)
            {
                // Move "currentCharacterRadians" on to the next character
                var distanceToNextChar = (characterWidths[characterIndex] + characterWidths[characterIndex + 1]) / 2F;
                float charFractionOfCircumference = distanceToNextChar / circleCircumference;
                currentCharacterRadians -= charFractionOfCircumference * (float)(2F * Math.PI);
            }
        }
    }
    private IEnumerable<float> GetCharacterWidths(Graphics graphics, string text, Font font)
    {
        // The length of a space. Necessary because a space measured using StringFormat.GenericTypographic has no width.
        // We can't use StringFormat.GenericDefault for the characters themselves, as it adds unwanted spacing.
        var spaceLength = graphics.MeasureString(" ", font, Point.Empty, StringFormat.GenericDefault).Width;
        return text.Select(c => c == ' ' ? spaceLength : graphics.MeasureString(c.ToString(), font, Point.Empty, StringFormat.GenericTypographic).Width);
    }
