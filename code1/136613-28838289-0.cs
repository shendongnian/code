    Imports System.ComponentModel.Design
    Imports System.Windows.Forms
    Imports System.ComponentModel
    Public Class BindingSourceExIsDirty
	Inherits System.Windows.Forms.BindingSource
	Implements INotifyPropertyChanged
 
 	#Region "DECLARATIONS AND PROPERTIES"
 
    Private _displayMember As String
    Private _dataTable As DataTable
    Private _dataSet As DataSet
    Private _parentBindingSource As BindingSource
    Private _form As System.Windows.Forms.Form
    Private _usercontrol As System.Windows.Forms.Control
 
 
 
    Private _isCurrentDirtyFlag As Boolean = False
    Public Property IsCurrentDirty() As Boolean
        Get
            Return _isCurrentDirtyFlag
        End Get
        Set(ByVal value As Boolean)
            If _isCurrentDirtyFlag <> value Then
            	_isCurrentDirtyFlag = value
            	Me.OnPropertyChanged(value.ToString())
                If value = True Then 'call the event when flag is set
                	OnCurrentIsDirty(New EventArgs)
                	
                End If
            End If
        End Set
    End Property
    
    Private _objectSource As String
    Public Property ObjectSource() As String
        Get
            Return _objectSource
        End Get
        Set(ByVal value As String)
        	_objectSource = value
        	Me.OnPropertyChanged(value)
        End Set
    End Property   
    
    
