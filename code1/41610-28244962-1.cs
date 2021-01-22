    Imports System.ComponentModel
    Public Class ExtendedListBox:Inherits ListBox:Implements INotifyPropertyChanged
        Public Shadows Property Items() As ObjectCollection
            Get
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Items"))
                Return MyBase.Items
            End Get
            Set(value As ObjectCollection)
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Items"))
                MyBase.Items.Clear()
                For Each o As Object In value
                    MyBase.Items.Add(o)
                Next
            End Set
        End Property
        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    End Class
