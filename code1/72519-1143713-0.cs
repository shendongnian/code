    ''' <summary>
    ''' Error - does not work if validSizes is Nothing, or has 0 elements, or if
    ''' the list contains a validSize that is not the closest one before a closer one,
    ''' or there are no valid sizes.
    ''' </summary>
    Public Function GetNextValidSize(ByVal size As Integer, ByVal validSizes As List(Of Integer)) As Integer
        Dim returnValue As Integer = size
        For i As Integer = 0 To validSizes.Count - 1 Step 1
            If validSizes.Item(i) >= size Then
                returnValue = validSizes.Item(i)
                Exit For
            End If
        Next
        Return returnValue
    End Function
    ''' <summary>
    ''' Returns the closest item in validSizes that is >= size. Throws an exception if one cannot 
    ''' be found.
    ''' </summary>
     Public Function GetNextValidSize2(ByVal size As Integer, ByVal validSizes As List(Of Integer)) As Integer
        Dim closestValue As Integer = Integer.MaxValue
        Dim found As Boolean = False
        If validSizes Is Nothing Then
            Throw New Exception("validSizes is nothing")
        End If
        If validSizes.Count = 0 Then
            Throw New Exception("No items in validSizes")
        End If
        For Each x In validSizes
            If x >= size Then
                found = True
                If x < closestValue Then
                    closestValue = x
                End If
            End If
        Next
        If Not found Then
            Throw New Exception("No items found")
        End If
        Return closestValue
    End Function
    ''' <summary>
    ''' Output the result of a test.
    ''' </summary>
     Public Sub outputResult(ByVal testName As String, ByVal result As Boolean, ByVal funcName As String)
        Dim passFail As String
        If result Then
            passFail = " passed"
        Else
            passFail = " failed"
        End If
        Console.WriteLine(testName & " : " & funcName & passFail)
    End Sub
    ''' <summary>
    ''' Output the result of a test where an exception occurred.
    ''' </summary>
     Public Sub outputResult(ByVal testName As String, ByVal ex As Exception, ByVal funcName As String)
        Console.WriteLine(testName & " : " & funcName & " " & ex.Message())
    End Sub
    ''' <summary>
    ''' Test with a list of 3 integers
    ''' </summary>
     Public Sub test1()
        Dim aList As New List(Of Integer)
        aList.Add(5)
        aList.Add(4)
        aList.Add(3)
        Dim result = GetNextValidSize(3, aList)
        outputResult("test1", 3 = GetNextValidSize(3, aList), "GetNextValidSize")
        outputResult("test1", 3 = GetNextValidSize2(3, aList), "GetNextValidSize2")
    End Sub
    ''' <summary>
    ''' Test with a null reference
    ''' </summary>
    Public Sub test2()
        Dim aList = Nothing
        Try
            outputResult("test2", GetNextValidSize(3, aList), "GetNextValidSize")
        Catch ex As Exception
            outputResult("test2", ex, "GetNextValidSize")
        End Try
        Try
            outputResult("test2", GetNextValidSize2(3, aList), "GetNextValidSize2")
        Catch ex As Exception
            outputResult("test2", ex, "GetNextValidSize2")
        End Try
    End Sub
    ''' <summary>
    ''' Test with an empty array.
    ''' </summary>
    Public Sub test3()
        Dim aList As New List(Of Integer)
        Try
            outputResult("test3", GetNextValidSize(3, aList), "GetNextValidSize")
        Catch ex As Exception
            outputResult("test3", ex, "GetNextValidSize")
        End Try
        Try
            outputResult("test3", GetNextValidSize2(3, aList), "GetNextValidSize2")
        Catch ex As Exception
            outputResult("test3", ex, "GetNextValidSize2")
        End Try
    End Sub
    ''' <summary>
    ''' Run all tests.
    ''' </summary>
    Public Sub testAll()
        test1()
        test2()
        test3()
    End Sub
    Sub Main()
        testAll()
        Console.ReadLine()
    End Sub
