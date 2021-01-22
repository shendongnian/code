    	public class SynchroniseDataGridEditingStateBehaviour : Behavior<DataGrid>
	{
		public static readonly DependencyProperty EditingStateBindingProperty =
			DependencyProperty.Register("EditingStateBinding", typeof(ISupportEditingState),
			typeof(SynchroniseDataGridEditingStateBehaviour), new PropertyMetadata(OnEditingStateBindingPropertyChange));
		private bool _attached;
		private bool _changingEditingState;
		public ISupportEditingState EditingStateBinding
		{
			get { return (ISupportEditingState)GetValue(EditingStateBindingProperty); }
			set { SetValue(EditingStateBindingProperty, value); }
		}
		private static void OnEditingStateBindingPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var b = d as SynchroniseDataGridEditingStateBehaviour;
			if (b == null)
				return;
			var oldNotifyChanged = e.OldValue as INotifyPropertyChanged;
			if (oldNotifyChanged != null)
				oldNotifyChanged.PropertyChanged -= b.OnEditingStatePropertyChanged;
			var newNotifyChanged = e.NewValue as INotifyPropertyChanged;
			if (newNotifyChanged != null)
				newNotifyChanged.PropertyChanged += b.OnEditingStatePropertyChanged;
			var newEditingStateSource = e.NewValue as ISupportEditingState;
			if (newEditingStateSource.EditingState == EditingState.Editing)
			{
				// todo: mh: decide on this behaviour once again.
				// maybe it's better to start editing if selected item is already bound in the DataGrid
				newEditingStateSource.EditingState = EditingState.LastCancelled;
			}
		}
		private static readonly string EditingStatePropertyName = 
			CodeUtils.GetPropertyNameByLambda<ISupportEditingState>(ses => ses.EditingState);
		private void OnEditingStatePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (_changingEditingState || !_attached || e.PropertyName != EditingStatePropertyName)
				return;
			_changingEditingState = true;
			
			var editingStateSource = sender as ISupportEditingState;
			if (editingStateSource == null)
				return;
			var grid = AssociatedObject;
			var editingState = editingStateSource.EditingState;
			switch (editingState)
			{
				case EditingState.Editing:
					grid.BeginEdit();
					break;
				case EditingState.LastCancelled:
					grid.CancelEdit();
					break;
				case EditingState.LastCommitted:
					grid.CommitEdit();
					break;
				default:
					throw new InvalidOperationException("Provided EditingState is not supported by the behaviour.");
			}
			_changingEditingState = false;
		}
		protected override void OnAttached()
		{
			var grid = AssociatedObject;
			grid.BeginningEdit += OnBeginningEdit;
			grid.RowEditEnded += OnEditEnded;
			_attached = true;
		}
		protected override void OnDetaching()
		{
			var grid = AssociatedObject;
			grid.BeginningEdit -= OnBeginningEdit;
			grid.RowEditEnded -= OnEditEnded;
			_attached = false;
		}
		void OnEditEnded(object sender, DataGridRowEditEndedEventArgs e)
		{
			if (_changingEditingState)
				return;
			EditingState editingState;
			if (e.EditAction == DataGridEditAction.Commit)
				editingState = EditingState.LastCommitted;
			else if (e.EditAction == DataGridEditAction.Cancel)
				editingState = EditingState.LastCancelled;
			else
				return; // if DataGridEditAction will ever be extended, this part must be changed
			EditingStateBinding.EditingState = editingState;
		}
		void OnBeginningEdit(object sender, DataGridBeginningEditEventArgs e)
		{
			if (_changingEditingState)
				return;
			EditingStateBinding.EditingState = EditingState.Editing;
		}
	}
