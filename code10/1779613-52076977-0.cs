    public override void ProcessEnd(IElementNode element, ProcessorContext context)
        {
        base.ProcessEnd(element, context);
        IPropertyContainer elementResult = base.GetElementResult();
        if (elementResult is IAccessibleElement)
        {
        string summary= element.GetAttribute("summary"); //This is the summary="tbl summary" in HTML
        AccessibilityProperties properties = ((IAccessibleElement)elementResult).GetAccessibilityProperties();
        properties.AddAttributes(new PdfStructureAttributes("Table").AddEnumAttribute("Summary", summary));
        }
        }
