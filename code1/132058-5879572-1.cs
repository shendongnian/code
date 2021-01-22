            private void OnPopupOpened(object sender, EventArgs e)
            {
                var popupAncestor = FindHighestAncestor(this.popup);
                if (popupAncestor == null)
                {
                    return;
                }
                popupAncestor.AddHandler(Windows.Popup.MouseLeftButtonDownEvent, (MouseButtonEventHandler)OnMouseLeftButtonDown, true);
            }
            private void OnPopupClosed(object sender, EventArgs e)
            {
                var popupAncestor = FindHighestAncestor(this.popup);
                if (popupAncestor == null)
                {
                    return;
                }
                popupAncestor.RemoveHandler(Windows.Popup.MouseLeftButtonDownEvent, (MouseButtonEventHandler)OnMouseLeftButtonDown);
            }
            private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                // in lieu of DependencyObject.SetCurrentValue, this is the easiest way to enact a change on the value of the Popup's IsOpen
                // property without overwriting any binding that may exist on it
                var storyboard = new Storyboard() { Duration = TimeSpan.Zero };
                var objectAnimation = new ObjectAnimationUsingKeyFrames() { Duration = TimeSpan.Zero };
                objectAnimation.KeyFrames.Add(new DiscreteObjectKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero), Value = false });
                Storyboard.SetTarget(objectAnimation, this.popup);
                Storyboard.SetTargetProperty(objectAnimation, new PropertyPath("IsOpen"));
                storyboard.Children.Add(objectAnimation);
                storyboard.Begin();
            }
		private static FrameworkElement FindHighestAncestor(Popup popup)
		{
			var ancestor = (FrameworkElement)popup;
			while (true) {
				var parent = VisualTreeHelper.GetParent(ancestor) as FrameworkElement;
				if (parent == null) {
					return ancestor;
				}
				ancestor = parent;
			}
		}
