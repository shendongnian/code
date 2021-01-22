using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
namespace System.Windows.Media.Animation
{
    class MaterialAnimation : AnimationTimeline
    {
                protected override Freezable CreateInstanceCore()
        {
            return new MaterialAnimation();
                    
        }
        public override Type TargetPropertyType
        {
            get { return typeof(Material); }
        }
        static MaterialAnimation()
        {
            FromProperty = DependencyProperty.Register("From", typeof(Material),
                typeof(MaterialAnimation));
            ToProperty = DependencyProperty.Register("To", typeof(Material),
                typeof(MaterialAnimation));
        }
        public static readonly DependencyProperty FromProperty;
        public Material From
        {
            get
            {
                return (Material)GetValue(MaterialAnimation.FromProperty);
            }
            set
            {
                SetValue(MaterialAnimation.FromProperty, value);
            }
        }
        public static readonly DependencyProperty ToProperty;
        public Material To
        {
            get
            {
                return (Material)GetValue(MaterialAnimation.ToProperty);
            }
            set
            {
                SetValue(MaterialAnimation.ToProperty, value);
            }
        }
        public override object GetCurrentValue(object defaultOriginValue,
        object defaultDestinationValue, AnimationClock animationClock)
        {
            Material fromVal = ((Material)GetValue(MaterialAnimation.FromProperty)).CloneCurrentValue();
            Material toVal = ((Material)GetValue(MaterialAnimation.ToProperty)).CloneCurrentValue();
            if ((double)animationClock.CurrentProgress == 0.0)
                return fromVal; //Here it workes fine.
            if ((double)animationClock.CurrentProgress == 1.0)
                return toVal;   //It workes also here fine.            
            if (toVal.GetType() == (new DiffuseMaterial()).GetType())
                ((DiffuseMaterial)toVal).Brush.Opacity = (double)animationClock.CurrentProgress;
            else
                if (toVal.GetType() == (new SpecularMaterial()).GetType())
                    ((SpecularMaterial)toVal).Brush.Opacity = (double)animationClock.CurrentProgress;
                else
                    ((EmissiveMaterial)toVal).Brush.Opacity = (double)animationClock.CurrentProgress;
            MaterialGroup MG = new MaterialGroup();
            MG.Children.Add(fromVal);
            MG.Children.Add(toVal);            
            return MG; 
        }
    }
}
