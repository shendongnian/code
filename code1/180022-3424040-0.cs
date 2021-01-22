    Imports System.ComponentModel
    Imports System.Windows
    Imports Microsoft.Practices.Composite.Events
    Imports WavelengthIS.Core.Services
    Imports WavelengthIS.Core.Bases
    Imports Ocean.OceanFramework.CommonDialog
    Imports WavelengthIS.WPF.Events
    
    Namespace WavelengthIS.WPF.Bases
    
        Public MustInherit Class ViewModelBase
            Inherits WavelengthIS.Core.Bases.Base
            Implements IDisposable, INotifyPropertyChanged
    
    #Region " Declarations "
            Private _headerinfo As String
            Private _backgroundworker As BackgroundWorker
            
    #End Region
    
    #Region " Properties "
            Public Property HeaderInfo() As String
                Get
                    Return _headerinfo
    
                End Get
                Set(ByVal value As String)
                    If Not (value Is String.Empty) Or Not (IsNothing(value)) Then
                        _headerinfo = value
                    End If
    
                End Set
            End Property
    
            Protected ReadOnly Property BackGroundWorker() As BackgroundWorker
                Get
                    If _backgroundworker Is Nothing Then
                        _backgroundworker = New BackgroundWorker
                    End If
                    Return _backgroundworker
                End Get
            End Property
    
            Private _isdirty As Boolean = False
            Protected Property IsDirty As Boolean
                Get
                    Return _isdirty
                End Get
                Set(ByVal value As Boolean)
                    If Not Equals(value, _isdirty) Then
                        _isdirty = value
                        If _isdirty = True Then
                            DisableNavigation()
                        Else
                            EnableNavigation()
                        End If
                    End If
                End Set
            End Property
    
            ''' <summary>
            ''' not a databinding property. No need for onpropertychanged notifications
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Protected Property IsLoading As Boolean = False
    
            Private _haschanges As Boolean
            Public Property HasChanges As Boolean
                Get
                    Return _haschanges
                End Get
                Set(ByVal value As Boolean)
                    If Not Equals(value, _haschanges) Then
                        _haschanges = value
                        If value = True Then
                            GetEvent(Of Events.DisableCloseButtonEvent).Publish(True)
                        End If
                        OnPropertyChanged("HasChanges")
                    End If
                End Set
            End Property
               
    
    #End Region
    
    #Region " Dialogs "
            'This is not in Bases because it would cause circular references.
    
            ''' <summary>
            ''' Gets the IDialogService registered with the ServiceContainer.
            ''' use ShowMessage or ShowException in child code.
            ''' </summary>
            Private ReadOnly Property Dialog() As Dialog.IDialogService
                Get
                    Return GetService(Of Dialog.IDialogService)()
                End Get
            End Property
    
            Protected Function ShowMessage(ByVal message As String, ByVal caption As String, ByVal button As Dialog.DialogButton, ByVal image As Dialog.DialogImage) As Ocean.OceanFramework.CommonDialog.CustomDialogResult
                GetEvent(Of Events.DialogShowingEvent).Publish(True)
                Dim rslt As CustomDialogResult = Dialog.ShowMessage(message, caption, button, image)
                GetEvent(Of Events.DialogShowingEvent).Publish(False)
                Return rslt
            End Function
    
            Protected Sub ShowException(ByVal message As String, Optional ByVal expandedMessage As String = Nothing, Optional ByVal image As Dialog.DialogImage = Core.Services.Dialog.DialogImage.Error)
                GetEvent(Of Events.DialogShowingEvent).Publish(True)
                Dialog.ShowException(message, expandedMessage, image)
                GetEvent(Of Events.DialogShowingEvent).Publish(False)
    
            End Sub
    #End Region
    
    #Region " Wait States "
    
            Private ReadOnly Property Wait As WavelengthIS.Core.Services.IWaitingService
                Get
                    Return GetService(Of IWaitingService)()
                End Get
            End Property
    
            Protected Sub BeginWait()
                GetEvent(Of Events.DisplayWaitingControlEvent).Publish(True)
            End Sub
    
            Protected Sub EndWait()
                GetEvent(Of Events.DisplayWaitingControlEvent).Publish(False)
            End Sub
    #End Region
    
    #Region " Events "
            Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    
    
    #End Region
    
    #Region " Constructor "
            Public Sub New()
                _backgroundworker = New BackgroundWorker
                AddHandler _backgroundworker.DoWork, AddressOf BackGroundWorker_DoWork
                AddHandler _backgroundworker.RunWorkerCompleted, AddressOf BackGroundWorker_RunWorkerCompleted
    
            End Sub
    
    #End Region
    
    #Region " IDisposable Support "
    
            Private disposedValue As Boolean = False        ' To detect redundant calls
    
            ' IDisposable
            Protected Overridable Sub Dispose(ByVal disposing As Boolean)
                If Not Me.disposedValue Then
                    If disposing Then
                        ' TODO: free other state (managed objects).
                    End If
    
                    ' TODO: free your own state (unmanaged objects).
                    ' TODO: set large fields to null.
                End If
                Me.disposedValue = True
            End Sub
            ' This code added by Visual Basic to correctly implement the disposable pattern.
            Public Sub Dispose() Implements IDisposable.Dispose
                ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
                Dispose(True)
                GC.SuppressFinalize(Me)
            End Sub
    #End Region
    
    #Region " Debugging Helpers "
            <Conditional("DEBUG")> _
            Public Sub VerifyPropertyName(ByVal propertyName As String)
    
                'If you raise PropertyChanged and do not specify a property name,
                'all properties on the object are considered to be changed by the binding system.
                If String.IsNullOrEmpty(propertyName) Then
                    Return
                End If
    
                ' Verify that the property name matches a real,  
                ' public, instance property on this object.
                'If TypeDescriptor.GetProperties(Me)(propertyName) Is Nothing Then
                '    Dim msg As String = "Invalid property name: " & propertyName
                '    Throw New Exception(msg)
                'End If
            End Sub
    
            Private _ThrowOnInvalidPropertyName As Boolean
            Protected Property ThrowOnInvalidPropertyName() As Boolean
                Get
                    Return _ThrowOnInvalidPropertyName
                End Get
                Private Set(ByVal value As Boolean)
                    _ThrowOnInvalidPropertyName = value
                End Set
            End Property
    
    
    
    
    #End Region
    
    #Region " INotifyProperty Changed Method "
    
    
            Protected Overridable Sub OnPropertyChanged(ByVal strPropertyName As String)
                Me.VerifyPropertyName(strPropertyName)
    
                If Me.PropertyChangedEvent IsNot Nothing Then
                    RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(strPropertyName))
                End If
    
    
            End Sub
    
            Private Function QualifyString(ByVal str As String) As Boolean
    
                
    
                Return True
    
            End Function
    
            Protected Overridable Sub OnPropertyChanged(ByVal strPropertyName As String, ByVal IsPrimaryProperty As Boolean)
                Me.OnPropertyChanged(strPropertyName)
    
            End Sub
    
    #End Region
    
    #Region " Navigation Events "
    
            Protected Sub EnableNavigation()
                'Keep from firing multiple onPropertyChanged events
                If HasChanges = True Then
                    HasChanges = False
                End If
    
                GetEvent(Of DisableNavigationEvent).Publish(False)
    
            End Sub
    
            Protected Sub DisableNavigation()
                'Keep from firing multiple onPropertyChanged events
                If HasChanges = False Then
                    HasChanges = True
                End If
    
                GetEvent(Of DisableNavigationEvent).Publish(True)
    
            End Sub
    
    #End Region
        End Class
    
    End Namespace
