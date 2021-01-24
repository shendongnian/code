    private static Cell GetCell(int position, ...)
    {
        var cell = new Cell();
        var isEven = (position + 1) % 2 == 0;
        if (image != null && record != null)
        {
            var paragraph = new Paragraph(
                    $"t1\n"
            );
            if (!string.IsNullOrEmpty(t2))
                paragraph.Add($"t2\n");
            // ...
            // This gives the original image height,
            // it doesn't take into account any set properties.
            float imageHeight = image.GetImageHeight();
            var div = new Div()
                    .Add(paragraph)
                    .SetHeight(imageHeight)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
            if (isEven) {
                image.SetMarginRight(5);
            } else {
                image.SetMarginLeft(5);
            }
            image.SetProperty(Property.FLOAT, isEven ? FloatPropertyValue.LEFT : FloatPropertyValue.RIGHT);
            cell.Add(image)
                    .Add(div)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        }
        cell.SetBorder(Border.NO_BORDER);
        cell.SetBackgroundColor(isEven ? WebColors.GetRGBColor("#DEDEDE") : WebColors.GetRGBColor("#FFFFFF"));
        return cell;
    }
