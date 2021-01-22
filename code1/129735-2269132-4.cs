    Public Class MTObservableCollection(Of T)
        Inherits ObservableCollection(Of T)
        Public Sub New()
            _DispatcherPriority = DispatcherPriority.DataBind
        End Sub
        Public Sub New(ByVal dispatcherPriority As DispatcherPriority)
            _DispatcherPriority = dispatcherPriority
        End Sub
        Private _DispatcherPriority As DispatcherPriority
       
        Public Overloads Overrides Event CollectionChanged As NotifyCollectionChangedEventHandler
        Protected Overloads Overrides Sub OnCollectionChanged(ByVal e As NotifyCollectionChangedEventArgs)
            Dim eh = CollectionChanged
            If eh IsNot Nothing Then
                Dim dispatcher As Dispatcher = (From nh In eh.GetInvocationList() _
                    Let dpo = TryCast(nh.Target, DispatcherObject) _
                    Where dpo IsNot Nothing _
                    Select dpo.Dispatcher).FirstOrDefault()
               
                If dispatcher IsNot Nothing AndAlso dispatcher.CheckAccess() = False Then
                    dispatcher.Invoke(DispatcherPriority.DataBind, DirectCast((Function() OnCollectionChanged(e)), Action))
                Else
                    For Each nh As NotifyCollectionChangedEventHandler In eh.GetInvocationList()
                        nh.Invoke(Me, e)
                    Next
                End If
            End If
        End Sub
       
    End Class
