    Get the Type of the CanAccessDatabase() class
    Using this type, get all methods in this class (optionally filtering public, private etc).
    Loop through the list of methods
        Call GetCustomAttributes() on the current method.
        Loop through the list of custom attributes
            If the IsEligibleCheck attribute is found
                If StaticClass.IsEligible is true
                    Call the current method (using MethodInfo.Invoke())
                End If
            End If
        End Loop
    End Loop
        
