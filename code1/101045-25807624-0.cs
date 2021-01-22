        public static class BehaviorInStyleAttacher
        {
            #region Attached Properties
            public static readonly DependencyProperty BehaviorsProperty =
                DependencyProperty.RegisterAttached(
                    "Behaviors",
                    typeof(BehaviorCreatorCollection),
                    typeof(BehaviorInStyleAttacher),
                    new UIPropertyMetadata(null, OnBehaviorsChanged));
            #endregion
            #region Getter and Setter of Attached Properties
            public static BehaviorCreatorCollection GetBehaviors(TreeView treeView)
            {
                return (BehaviorCreatorCollection)treeView.GetValue(BehaviorsProperty);
            }
            public static void SetBehaviors(
                TreeView treeView, BehaviorCreatorCollection value)
            {
                treeView.SetValue(BehaviorsProperty, value);
            }
            #endregion
            #region on property changed methods
            private static void OnBehaviorsChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
            {
                if (e.NewValue is BehaviorCreatorCollection == false)
                    return;
                BehaviorCreatorCollection newBehaviorCollection = e.NewValue as BehaviorCreatorCollection;
                BehaviorCollection behaviorCollection = Interaction.GetBehaviors(depObj);
                behaviorCollection.Clear();
                foreach (IBehaviorCreator behavior in newBehaviorCollection)
                {
                    behaviorCollection.Add(behavior.Create());
                }
            }
            #endregion
        }
