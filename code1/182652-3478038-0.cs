	Public Property CurrentPersonCancellable() As Person
		Get
			Debug.WriteLine("Getting CurrentPersonCancellable.")
			Return _CurrentPersonCancellable
		End Get
		Set
			' Store the current value so that we can '
			' change it back if needed.'
			Dim origValue = _CurrentPersonCancellable
			' If the value hasnt changed, dont do anything.'
			If value = _CurrentPersonCancellable Then
				Return
			End If
			' Note that we actually change the value for now.'
			' This is necessary because WPF seems to query the '
			'  value after the change. The combo box'
			' likes to know that the value did change.'
			_CurrentPersonCancellable = value
			If MessageBox.Show("Allow change of selected item?", "Continue", MessageBoxButton.YesNo) <> MessageBoxResult.Yes Then
				Debug.WriteLine("Selection Cancelled.")
				' change the value back, but do so after the '
				' UI has finished its current context operation.'
				Application.Current.Dispatcher.BeginInvoke(New Action(of Person)(addressof dispatcherCallerHelper), _
														   DispatcherPriority.ContextIdle, _
														   new Object() {origValue})
				' Exit early. '
				Return
			End If
			' Normal path. Selection applied. '
			' Raise PropertyChanged on the field.'
			Debug.WriteLine("Selection applied.")
			OnPropertyChanged("CurrentPersonCancellable")
		End Set
	End Property
	private sub dispatcherCallerHelper(origValue as Person)
		Debug.WriteLine("Dispatcher BeginInvoke " & "Setting CurrentPersonCancellable.")
		' Do this against the underlying value so '
		'  that we dont invoke the cancellation question again.'
		_CurrentPersonCancellable = origValue
		OnPropertyChanged("CurrentPersonCancellable")
	end sub
