    private static UIElement ClonedElement(UIElement original)
    {
        var clone = (UIElement)XamlReader.Parse(XamlWriter.Save(original));
        if (original is TextBlock)
            //Handles situation where databinding doesn't clone correctly.
            ((TextBlock)clone).Text = ((TextBlock)original).Text;
        return clone;
    }
