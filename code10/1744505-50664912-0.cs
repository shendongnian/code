    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media.Animation;
    
    namespace Infrastructure.Animations
    {
        public class GridLengthAnimation : AnimationTimeline
        {
            protected override Freezable CreateInstanceCore()
            {
                return new GridLengthAnimation();
            }
    
            public override Type TargetPropertyType => typeof(GridLength);
    
            static GridLengthAnimation()
            {
                FromProperty = DependencyProperty.Register("From", typeof(GridLength),
                    typeof(GridLengthAnimation));
    
                ToProperty = DependencyProperty.Register("To", typeof(GridLength),
                    typeof(GridLengthAnimation));
            }
    
            public static readonly DependencyProperty FromProperty;
            public GridLength From
            {
                get => (GridLength)GetValue(GridLengthAnimation.FromProperty);
                set => SetValue(GridLengthAnimation.FromProperty, value);
            }
    
            public static readonly DependencyProperty ToProperty;
            public GridLength To
            {
                get => (GridLength)GetValue(GridLengthAnimation.ToProperty);
                set => SetValue(GridLengthAnimation.ToProperty, value);
            }
    
            public override object GetCurrentValue(object defaultOriginValue,
        object defaultDestinationValue, AnimationClock animationClock)
            {
                double fromVal = ((GridLength)GetValue(GridLengthAnimation.FromProperty)).Value;
                double toVal = ((GridLength)GetValue(GridLengthAnimation.ToProperty)).Value;
                if (fromVal > toVal)
                {
                    return new GridLength((1 - animationClock.CurrentProgress.Value) *
                        (fromVal - toVal) + toVal, GridUnitType.Pixel);
                }
                else
                {
                    return new GridLength(animationClock.CurrentProgress.Value *
                        (toVal - fromVal) + fromVal, GridUnitType.Pixel);
                }
            }
        }
    }
