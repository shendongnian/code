    public class MinSpeedDoubleAnimation : DoubleAnimation
    {
        public static readonly DependencyProperty MinSpeedProperty =
            DependencyProperty.Register(
                nameof(MinSpeed), typeof(double?), typeof(MinSpeedDoubleAnimation));
        public double? MinSpeed
        {
            get { return (double?)GetValue(MinSpeedProperty); }
            set { SetValue(MinSpeedProperty, value); }
        }
        protected override Freezable CreateInstanceCore()
        {
            return new MinSpeedDoubleAnimation();
        }
        protected override double GetCurrentValueCore(
            double defaultOriginValue, double defaultDestinationValue,
            AnimationClock animationClock)
        {
            var destinationValue = To ?? defaultDestinationValue;
            var originValue = From ?? defaultOriginValue;
            var speed = (destinationValue - originValue) / Duration.TimeSpan.TotalSeconds;
            if (MinSpeed.HasValue && Math.Abs(speed) < MinSpeed)
            {
                speed = Math.Sign(speed) * MinSpeed.Value;
            }
            var value = originValue + speed * animationClock.CurrentTime.Value.TotalSeconds;
            return speed > 0 ?
                Math.Min(destinationValue, value) :
                Math.Max(destinationValue, value);
        }
    }
