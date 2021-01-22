    using System;
	using System.Collections.Generic;
	using System.Reactive;
	using System.Reactive.Linq;
	using System.Windows;
	using System.Windows.Controls;
	using Common.Logging;
	namespace AttachedProperties
	{
		/// <summary>
		/// Intent: Ensures that any floating dock windows are always topmost.
		/// </summary>
		public class EnsureWindowInForeground
		{
			public static readonly DependencyProperty EnsureWindowInForegroundProperty = DependencyProperty.RegisterAttached(
				"EnsureWindowInForeground",
				typeof(bool),
				typeof(EnsureWindowInForeground),
				new PropertyMetadata(true, EnsureWindowInForegroundPropertyChanged));
			private static readonly Dictionary<UserControl, TrackVisibility> _trackVisibility = new Dictionary<UserControl, TrackVisibility>();
			private static readonly object _trackVisibilityLock = new object();
			/// <summary>
			///	Intent: Tracks whether a class should be visible, or invisible.
			/// </summary>
			private class TrackVisibility
			{
				public TrackVisibility(UserControl userControl, Window parentWindow, bool shouldBeVisible, IDisposable subscriptionOnLoad, IDisposable subscriptionIsVisibleChanged)
				{
					UserControl = userControl;
					ParentWindow = parentWindow;
					ShouldBeVisible = shouldBeVisible;
					SubscriptionOnLoad = subscriptionOnLoad;
					SubscriptionIsVisibleChanged = subscriptionIsVisibleChanged;
				}
				public Window ParentWindow { get; set; }
				public UserControl UserControl { get; set; }
				public bool ShouldBeVisible { get; set; }
				public IDisposable SubscriptionOnLoad { get; private set; }
				public IDisposable SubscriptionIsVisibleChanged { get; set; }
			}
			private static void EnsureWindowInForegroundPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
			{
				try
				{
					bool targetValueIfVisible = (bool)dependencyPropertyChangedEventArgs.NewValue;
					UserControl userControl = dependencyObject as UserControl;
					if (userControl == null)
					{
						_log.Warn($"Warning W62344. Attached propery {nameof(EnsureWindowInForeground)} must be of type {nameof(UserControl)} (or any other type that handles the 'OnLoaded' event).");
						return;
					}
					lock (_trackVisibilityLock)
					{
						TrackVisibility trackVisibility;
						if (_trackVisibility.TryGetValue(userControl, out trackVisibility) == false)
						{
							// We require a hook into OnLoaded, because the Visual Tree is only ready after the control is loaded.
							var subscription1 = LoadedObserver(userControl);
							
							IDisposable subscriptionOnLoad = subscription1.Subscribe(o => UserControl_Loaded(o.Sender as UserControl, o.EventArgs));
							trackVisibility = new TrackVisibility(userControl, null, targetValueIfVisible, subscriptionOnLoad, null);
							_trackVisibility[userControl] = trackVisibility;
						}					
						trackVisibility.ShouldBeVisible = targetValueIfVisible;
					}
					ControlWindowVisibility(userControl);
				}
				catch (Exception ex)
				{
					_log.Warn($"Warning W88244. Exception in Attached Property '{nameof(EnsureWindowInForeground)}'", ex);
				}
			}
			/// <summary>
			///	Intent: Converts event into Observable. See
			///	https://github.com/WilkaH/EventToObservableReflection/blob/master/ExampleOutput/WindowEventToObservableExtensions.cs. 
			/// </summary>
			private static IObservable<EventPattern<RoutedEventArgs>> LoadedObserver(UserControl This)
			{
				return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(h => This.Loaded += h, h => This.Loaded -= h);
			}
			/// <summary>
			/// Intent: If we attempt to do *anything* before the control has loaded, we will have intermittent issues.
			/// http://stackoverflow.com/questions/36037963/wpf-in-an-attached-property-how-to-wait-until-visual-tree-loaded-properly
			/// </summary>
			private static void UserControl_Loaded(UserControl userControl, RoutedEventArgs args)
			{
				try
				{
					if (userControl == null)
					{
						_log.Warn(
							$"Warning W92344. In '{nameof(UserControl_Loaded)}', the UserControl is null.");
						return;
					}
					var parentWindow = userControl.MyGetParentVisualTreeWindow();
					if (parentWindow == null)
					{
						_log.Warn(
							$"Warning W16644. In '{nameof(UserControl_Loaded)}', the sender cannot be cast to type '{nameof(UserControl)}'.");
						return;
					}
					lock (_trackVisibilityLock)
					{
						TrackVisibility trackVisibility;
						if (_trackVisibility.TryGetValue(userControl, out trackVisibility) == false)
						{
							_log.Warn("Warning W62344. Internal program error; could not find stats for Window.");
							return;
						}
						trackVisibility.ParentWindow = parentWindow;
						if (trackVisibility.SubscriptionIsVisibleChanged == null)
						{
							// We require a hook into IsVisibleChanged, so that if the parent is minimised, we can show things again.
							var subscription2 = IsVisibleChangedObserver(userControl);
							trackVisibility.SubscriptionIsVisibleChanged =
								subscription2.Subscribe(o => UserControl_IsVisibleChanged(o.Sender as UserControl, o.EventArgs));
						}
					}
					ControlWindowVisibility(userControl);
				}
				catch (Exception ex)
				{
					_log.Warn($"Warning W19844. Exception in Attached Property '{nameof(EnsureWindowInForeground)}'.", ex);
				}
			}
			/// <summary>
			///	Intent: Converts event into Observable. See
			///	https://github.com/WilkaH/EventToObservableReflection/blob/master/ExampleOutput/WindowEventToObservableExtensions.cs. 
			/// </summary>
			private static IObservable<EventPattern<DependencyPropertyChangedEventArgs>> IsVisibleChangedObserver(UserControl window)
			{
				return Observable.FromEventPattern<DependencyPropertyChangedEventHandler, DependencyPropertyChangedEventArgs>(h => window.IsVisibleChanged += h, h => window.IsVisibleChanged -= h);
			}
			private static void UserControl_IsVisibleChanged(UserControl sender, DependencyPropertyChangedEventArgs args)
			{
				ControlWindowVisibility(sender);
			}
			private static void ControlWindowVisibility(UserControl userControl)
			{
				Application.Current.Dispatcher.Invoke(
					() =>
					{
						try
						{
							if (userControl == null)
							{
								_log.Warn(
									$"Warning W62344. In '{nameof(UserControl_Loaded)}', the UserControl is null.");
								return;
							}
							var parentWindow = userControl.MyGetParentVisualTreeWindow();
							if (parentWindow == null)
							{
								// This is normal; if we call this before the visual tree has loaded and the 'Loaded' event has fired, it will create a warning.
								return;
							}
							bool shouldBeVisibleMirror = true;
							lock (_trackVisibilityLock)
							{
								TrackVisibility trackVisibility;
								if (_trackVisibility.TryGetValue(userControl, out trackVisibility) == false)
								{
									_log.Warn("Warning W62344. Internal program error; could not find stats for Window.");
									return;
								}
								shouldBeVisibleMirror = trackVisibility.ShouldBeVisible;
								trackVisibility.ParentWindow = parentWindow;
							}
							if (shouldBeVisibleMirror == true)
							{
								HideAndShowWindowHelper.ShiftWindowIntoForeground(parentWindow);
								ShiftWindowOntoScreenHelper.ShiftWindowOntoScreen(parentWindow);
								_log.Debug($"Showing window: {parentWindow}\n");
							}
							else
							{
								HideAndShowWindowHelper.ShiftWindowIntoBackground(parentWindow);
								_log.Debug($"Hiding window: {parentWindow}\n");
							}
						}
						catch (Exception ex)
						{
							_log.Warn($"Warning W19844. Exception in Attached Property '{nameof(EnsureWindowInForeground)}'.", ex);
						}
					});
			}
			public static void SetEnsureWindowInForeground(DependencyObject element, bool value)
			{
				element.SetValue(EnsureWindowInForegroundProperty, value);
			}
			public static bool GetEnsureWindowInForeground(DependencyObject element)
			{
				return (bool)element.GetValue(EnsureWindowInForegroundProperty);
			}
		}
	}
