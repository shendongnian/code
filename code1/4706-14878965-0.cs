        foreach(var child in svgDocument.Children)
        {
            SetFont(child);
        }
        public void SetFont(SvgElement element)
        {
            foreach(var child in element.Children)
            {
                SetFont(child); //Call this function again with the child, this will loop
                                //until the element has no more children
            }
            try
            {
                var svgText = (SvgText)parent; //try to cast the element as a SvgText
                                               //if it succeeds you can modify the font
                svgText.Font = new Font("Arial", 12.0f);
                svgText.FontSize = new SvgUnit(12.0f);
            }
            catch
            {
            }
        }
