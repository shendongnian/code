    Public NotInheritable Class DataContextHelper
    
          Private Const StandardChangeTrackerName As String = "System.Data.Linq.ChangeTracker+StandardChangeTracker"
        
            Public Shared Function FindContextFor(ByVal this as DataContext, ByVal caller As Object) As JFDataContext
                Dim hasContext As Boolean = False
                Dim myType As Type = caller.GetType()
                Dim propertyChangingField As FieldInfo = myType.GetField("PropertyChangingEvent", BindingFlags.NonPublic Or BindingFlags.Instance)
                Dim propertyChangingDelegate As PropertyChangingEventHandler = propertyChangingField.GetValue(caller)
                Dim delegateType As Type = Nothing
        
                For Each thisDelegate In propertyChangingDelegate.GetInvocationList()
                    delegateType = thisDelegate.Target.GetType()
                    If delegateType.FullName.Equals(StandardChangeTrackerName) Then
                        propertyChangingDelegate = thisDelegate
        
                        Dim targetField = propertyChangingDelegate.Target
                        Dim servicesField As FieldInfo = targetField.GetType().GetField("services", BindingFlags.NonPublic Or BindingFlags.Instance)
                        If servicesField IsNot Nothing Then
                            Dim servicesObject = servicesField.GetValue(targetField)
                            Dim contextField As FieldInfo = servicesObject.GetType.GetField("context", BindingFlags.NonPublic Or BindingFlags.Instance)
                            Return contextField.GetValue(servicesObject)
                        End If
                    End If
                Next
        
                Return Nothing
            End Function
