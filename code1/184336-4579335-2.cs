    Public ReadOnly Property DirtyObjects() As IEnumerable(Of ObjectStateEntry)
      Get
        Return ObjectStateManager.GetObjectStateEntries(
          EntityState.Added Or 
          EntityState.Deleted Or 
          EntityState.Modified)
      End Get
    End Property
     Public Overloads Sub Refresh()
      For Each entry In DirtyObjects
        Select Case entry.State
          Case EntityState.Modified
            Dim original = entry.OriginalValues
            For Each prop In entry.GetModifiedProperties
              Dim ordinal = original.GetOrdinal(prop)
              entry.CurrentValues.SetValue(ordinal, original(ordinal))
              RaisePropertyChanged(entry.Entity, prop)
            Next
            entry.AcceptChanges()
          Case EntityState.Deleted
            entry.ChangeState(EntityState.Unchanged)
          Case EntityState.Added
            entry.ChangeState(EntityState.Detached)
          Case Else
            'do nothing
            Debug.Fail("It's not supposed to stop here.")
        End Select
      Next
    End Sub
