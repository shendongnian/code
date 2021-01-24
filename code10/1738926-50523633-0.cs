    public class ProportionalPanel : Panel
    {
        protected override Size MeasureOverride(Size constraint)
        {
            /* Here we measure all children and return minimal size this panel
             * needs to be to show all children without clipping while maintaining
             * the desired proportions between them. We should try, but are not
             * obliged to, fit into the given constraint (available size) */
            var desiredSize = new Size();
            if (Children.Count > 0)
            {
                var children = Children.Cast<UIElement>().ToList();
                var weights = children.Select(GetWeight).ToList();
                var totalWeight = weights.Sum();
                var unitWidth = 0d;
                if (totalWeight == 0)
                {
                    //We should handle the situation when all children have weights set
                    //to 0. One option is to measure them with 0 available space. To do
                    //so we simply set totalWeight to something other than 0 to avoid
                    //division by 0 later on.
                    totalWeight = children.Count;
                    //We could also assume they are to be arranged uniformly, so we
                    //simply coerce their weights to 1
                    for (var i = 0; i < weights.Count; i++)
                        weights[i] = 1;
                }
                for (var i = 0; i < children.Count; i++)
                {
                    var child = children[i];
                    child.Measure(new Size
                    {
                        Width = constraint.Width * weights[i] / totalWeight,
                        Height = constraint.Height
                    });
                    desiredSize.Width += child.DesiredSize.Width;
                    desiredSize.Height =
                        Math.Max(desiredSize.Height, child.DesiredSize.Height);
                    if (weights[i] != 0)
                        unitWidth =
                            Math.Max(unitWidth, child.DesiredSize.Width / weights[i]);
                }
                if (double.IsPositiveInfinity(constraint.Width))
                {
                    //If there's unlimited space (e.g. when the panel is nested in a Viewbox
                    //or a StackPanel) we need to adjust the desired width so that no child
                    //is given less than desired space while maintaining the desired
                    //proportions between them
                    desiredSize.Width = totalWeight * unitWidth;
                }
            }
            return desiredSize;
        }
        protected override Size ArrangeOverride(Size constraint)
        {
            /* Here we arrange all children into their places and return the
             * actual size this panel is. The constraint will never be smaller
             * than the value of DesiredSize property, which is determined in 
             * the MeasureOverride method. If the desired size is larger than
             * the size of parent element, the panel will simply be clipped 
             * or appear "outside" of the parent element */
            var size = new Size();
            if (Children.Count > 0)
            {
                var children = Children.Cast<UIElement>().ToList();
                var weights = children.Select(GetWeight).ToList();
                var totalWeight = weights.Sum();
                if (totalWeight == 0)
                {
                    //We perform same routine as in MeasureOverride
                    totalWeight = children.Count;
                    for (var i = 0; i < weights.Count; i++)
                        weights[i] = 1;
                }
                var offset = 0d;
                for (var i = 0; i < children.Count; i++)
                {
                    var width = constraint.Width * weights[i] / totalWeight;
                    children[i].Arrange(new Rect
                    {
                        X = offset,
                        Width = width,
                        Height = constraint.Height,
                    });
                    offset += width;
                    size.Width += children[i].RenderSize.Width;
                    size.Height = Math.Max(size.Height, children[i].RenderSize.Height);
                }
            }
            return size;
        }
        public static readonly DependencyProperty WeightProperty =
            DependencyProperty.RegisterAttached(
                name: "Weight",
                propertyType: typeof(double),
                ownerType: typeof(ProportionalPanel),
                defaultMetadata: new FrameworkPropertyMetadata
                {
                    AffectsParentArrange = true, //because it's set on children and is used
                                                 //in parent panel's ArrageOverride method
                    AffectsParentMeasure = true, //because it's set on children and is used
                                                 //in parent panel's MeasuerOverride method
                    DefaultValue = 1d,
                },
                validateValueCallback: ValidateWeight);
        private static bool ValidateWeight(object value)
        {
            //We want the value to be not less than 0 and finite
            return value is double d
                && d >= 0 //this excludes double.NaN and double.NegativeInfinity
                && !double.IsPositiveInfinity(d);
        }
        public static double GetWeight(UIElement d)
            => (double)d.GetValue(WeightProperty);
        public static void SetWeight(UIElement d, double value)
            => d.SetValue(WeightProperty, value);
    }
