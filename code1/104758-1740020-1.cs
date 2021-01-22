    Option Explicit
    
    Private m_blnInitialized As Boolean
    Private m_lngID As Long
    Private m_strFirstName As String
    
    Public Sub Initialize(ByVal ID As Long, Optional ByVal someOtherThing As String = vbNullString)
        If m_blnInitialized Then Me.Clear
        m_lngID = ID
        m_strFirstName = SomeLookUp()
        If LenB(someOtherThing) Then
            ''Do something here.
        End If
        m_blnInitialized = True
    End Sub
    
    Public Property Get ID() As Long
        If Not m_blnInitialized Then Err.Raise eStandardErrors.eNotInitialized
        ID = m_lngID
    End Property
    
    Public Property Get FirstName() As String
        If Not m_blnInitialized Then Err.Raise eStandardErrors.eNotInitialized
        FirstName = m_strFirstName
    End Property
    
    Private Function SomeLookUp() As String
        ''perform magic on Me.ID
    End Function
    
    Public Sub LoadPicture()
        If Not m_blnInitialized Then Err.Raise eStandardErrors.eNotInitialized
        ''More magic
    End Sub
    
    Public Sub Clear()
        If Not m_blnInitialized Then Err.Raise eStandardErrors.eNotInitialized
        m_strFirstName = vbNullString
        m_lngID = 0&
        m_blnInitialized = False
    End Sub
