    Imports System.Collections.Generic
    
    
    Partial Class Default2
        Inherits System.Web.UI.Page
    
        ''# we need to create an array of our control list class
        Public Shared _empList As List(Of EmployeeList)
    
    
    
        ''# button click event
        Protected Sub AddStuff
    
            ''# create a new employee
            Dim emp As Employee = New Employee
            With emp
                .Name = "Joe"
                .Company = "Acme Welding"
            End With
    
            ''# add the employee to our custom array
            _empList.Add(New ControlList(emp))
        End Sub
    
    
    
        ''# this is our custom Employee List
        ''# the idea behind this is for us to store 
        Public Class EmployeeList
            Private _employee As Employee
            Public Property Employee As Employee
                Get
                    Return _employee
                End Get
                Set(ByVal value As Employee)
                    _employee = value
                End Set
            End Property
    
            Public Sub New(ByVal employee As Employee)
                _employee = employee
            End Sub
    
        End Class
    
    
    End Class
