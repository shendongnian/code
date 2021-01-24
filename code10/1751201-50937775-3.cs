    Imports System.ComponentModel
    
    Public Class Class1
        Implements INotifyPropertyChanged
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    
        Private _ModeSta1 As Boolean
        Property ModeSta1 As Boolean
            Get
                Return _ModeSta1
            End Get
            Set(ByVal value As Boolean)
                _ModeSta1 = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(ModeSta1)))
            End Set
        End Property
    
    End Class
