    // Adds a collection of command bindings to a date picker's existing BlackoutDates collection, since the collections are immutable and can't be bound to otherwise.
	// Usage: <DatePicker CalendarAttachedProperties.RegisterBlackoutDates="{Binding BlackoutDates}" >
	public class CalendarAttachedProperties : DependencyObject
	{
		#region Attributes
		private static readonly List<Calendar> _calendars = new List<Calendar>();
		private static readonly List<DatePicker> _datePickers = new List<DatePicker>();
		#endregion
		#region Dependency Properties
		public static DependencyProperty RegisterBlackoutDatesProperty = DependencyProperty.RegisterAttached("RegisterBlackoutDates", typeof(CalendarBlackoutDatesCollection), typeof(CalendarAttachedProperties), new PropertyMetadata(null, OnRegisterCommandBindingChanged));
		public static void SetRegisterBlackoutDates(DependencyObject d, CalendarBlackoutDatesCollection value)
		{
			d.SetValue(RegisterBlackoutDatesProperty, value);
		}
		public static CalendarBlackoutDatesCollection GetRegisterBlackoutDates(DependencyObject d)
		{
			return (CalendarBlackoutDatesCollection)d.GetValue(RegisterBlackoutDatesProperty);
		}
		#endregion
		#region Event Handlers
		private static void CalendarBindings_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			CalendarBlackoutDatesCollection blackoutDates = sender as CalendarBlackoutDatesCollection;
			Calendar calendar = _calendars.First(c => c.Tag == blackoutDates);
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				foreach (CalendarDateRange dateRange in e.NewItems)
				{
					calendar.BlackoutDates.Add(dateRange);
				}
			}
		}
		private static void DatePickerBindings_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			CalendarBlackoutDatesCollection blackoutDates = sender as CalendarBlackoutDatesCollection;
			DatePicker datePicker = _datePickers.First(c => c.Tag == blackoutDates);
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				foreach (CalendarDateRange dateRange in e.NewItems)
				{
					datePicker.BlackoutDates.Add(dateRange);
				}
			}
		}
		#endregion
		#region Private Methods
		private static void OnRegisterCommandBindingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			Calendar calendar = sender as Calendar;
			if (calendar != null)
			{
				CalendarBlackoutDatesCollection bindings = e.NewValue as CalendarBlackoutDatesCollection;
				if (bindings != null)
				{
					if (!_calendars.Contains(calendar))
					{
						calendar.Tag = bindings;
						_calendars.Add(calendar);
					}
					calendar.BlackoutDates.Clear();
					foreach (var dateRange in bindings)
					{
						calendar.BlackoutDates.Add(dateRange);
					}
					bindings.CollectionChanged += CalendarBindings_CollectionChanged;
				}
			}
			else
			{
				DatePicker datePicker = sender as DatePicker;
				if (datePicker != null)
				{
					CalendarBlackoutDatesCollection bindings = e.NewValue as CalendarBlackoutDatesCollection;
					if (bindings != null)
					{
						if (!_datePickers.Contains(datePicker))
						{
							datePicker.Tag = bindings;
							_datePickers.Add(datePicker);
						}
						datePicker.BlackoutDates.Clear();
						foreach (var dateRange in bindings)
						{
							datePicker.BlackoutDates.Add(dateRange);
						}
						bindings.CollectionChanged += DatePickerBindings_CollectionChanged;
					}
				}
			}
		}
		#endregion
	}
