    public class CustomTemplateSelectors : DataTemplateSelector
    {
        public DataTemplate CanvasElementTemplate { get; set; }
        public DataTemplate LineTemplate { get; set; }
        public DataTemplate LabelTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is CanvasElement)
                return CanvasElementTemplate;
            else if (item is CustomLine)
                return LineTemplate;
            else if (item is LabelTextBlock)
                return LabelTemplate;
            else return base.SelectTemplate(item, container);
        }
    }
    public class CustomStyleSelector : StyleSelector
    {
        public Style CanvasStyle_TL { get; set; }
        public Style CanvasStyle_TR { get; set; }
        public Style CanvasStyle_BL { get; set; }
        public Style CanvasStyle_BR { get; set; }
        public Style LineStyle { get; set; }
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item is CanvasElement)
                return CanvasStyle_TL;
            else if (item is CustomLine)
                return LineStyle;
            else if (item is LabelTextBlock)
            {
                var tempItem = item as LabelTextBlock;
                if (tempItem.Tag == "TL")
                    return CanvasStyle_TL;
                else if (tempItem.Tag == "TR")
                    return CanvasStyle_TR;
                else if (tempItem.Tag == "BL")
                    return CanvasStyle_BL;
                else if (tempItem.Tag == "BR")
                    return CanvasStyle_BR;
                else return base.SelectStyle(item, container);
            }
            else return base.SelectStyle(item, container);
        }
    }
