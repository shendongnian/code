    public static class BehaviorInStyleAttacher
    {
        #region Attached Properties
        public static readonly DependencyProperty BehaviorsProperty =
            DependencyProperty.RegisterAttached(
                "Behaviors",
                typeof(IEnumerable),
                typeof(BehaviorInStyleAttacher),
                new UIPropertyMetadata(null, OnBehaviorsChanged));
        #endregion
        #region Getter and Setter of Attached Properties
        public static IEnumerable GetBehaviors(DependencyObject dependencyObject)
        {
            return (IEnumerable)dependencyObject.GetValue(BehaviorsProperty);
        }
        public static void SetBehaviors(
            DependencyObject dependencyObject, IEnumerable value)
        {
            dependencyObject.SetValue(BehaviorsProperty, value);
        }
        #endregion
        #region on property changed methods
        private static void OnBehaviorsChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is IEnumerable == false)
                return;
            var newBehaviorCollection = e.NewValue as IEnumerable;
            BehaviorCollection behaviorCollection = Interaction.GetBehaviors(depObj);
            behaviorCollection.Clear();
            foreach (Behavior behavior in newBehaviorCollection)
            {
                behaviorCollection.Add(behavior);
            }
        }
        #endregion
    }
