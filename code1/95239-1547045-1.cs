using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media.Media3D;
namespace System.Windows.Media.Animation
{
    public class Point3DCollectionAnimation : AnimationTimeline
    {
        protected override Freezable CreateInstanceCore()
        {
            return new Point3DCollectionAnimation();
        }
        public override Type TargetPropertyType
        {
            get { return typeof(Point3DCollection); }
        }
        static Point3DCollectionAnimation()
        {
            FromProperty = DependencyProperty.Register("From", typeof(Point3DCollection),
                typeof(Point3DCollectionAnimation));
            ToProperty = DependencyProperty.Register("To", typeof(Point3DCollection),
                typeof(Point3DCollectionAnimation));
        }
        public static readonly DependencyProperty FromProperty;
        public Point3DCollection From
        {
            get
            {
                return (Point3DCollection)GetValue(Point3DCollectionAnimation.FromProperty);
            }
            set
            {
                SetValue(Point3DCollectionAnimation.FromProperty, value);
            }
        }
        public static readonly DependencyProperty ToProperty;
        public Point3DCollection To
        {
            get
            {
                return (Point3DCollection)GetValue(Point3DCollectionAnimation.ToProperty);
            }
            set
            {
                SetValue(Point3DCollectionAnimation.ToProperty, value);
            }
        }
        public override object GetCurrentValue(object defaultOriginValue,
        object defaultDestinationValue, AnimationClock animationClock)
        {
            Point3DCollection fromVal = ((Point3DCollection)GetValue(Point3DCollectionAnimation.FromProperty));
            Point3DCollection toVal = ((Point3DCollection)GetValue(Point3DCollectionAnimation.ToProperty));
            Point3DCollection ret;
            int t = 0;
            if (fromVal.Count > toVal.Count)
            {
                ret = fromVal.Clone();
                foreach (Point3D tov in toVal)
                {
                    Point3D frov = fromVal[t];
                    Point3D newv = new Point3D();
                    newv.X = (double)animationClock.CurrentProgress * (tov.X - frov.X) + frov.X;
                    newv.Y = (double)animationClock.CurrentProgress * (tov.Y - frov.Y) + frov.Y;
                    newv.Z = (double)animationClock.CurrentProgress * (tov.Z - frov.Z) + frov.Z;
                    ret[t] = newv;
                    t++;
                }
            }
            else
            {
                ret = toVal.Clone();
                foreach (Point3D frov in fromVal)
                {
                    Point3D tov = toVal[t];
                    Point3D newv = new Point3D();
                    newv.X = (double)animationClock.CurrentProgress * (tov.X - frov.X) + frov.X;
                    newv.Y = (double)animationClock.CurrentProgress * (tov.Y - frov.Y) + frov.Y;
                    newv.Z = (double)animationClock.CurrentProgress * (tov.Z - frov.Z) + frov.Z;
                    ret[t] = newv;
                    t++;
                }
            }
            return ret;
        }
    }
}
