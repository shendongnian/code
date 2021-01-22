    Namespace Data
    #Region "Interface"
        Public Interface IUserRepository
            Function GetAllUsers() As IList(Of User)
            Function GetUserByID(ByVal id As Integer) As User
        End Interface
    #End Region
    
    #Region "Repository"
        Public Class UserRepository : Implements IUserRepository
            Private dc As MyDataContext
            Public Sub New()
                dc = New MyDataContext
            End Sub
    
            Public Function GetAllUsers() As System.Collections.Generic.IList(Of User) Implements IUserRepository.GetAllUsers
                Dim users = From u In dc.Users
                            Select u
                Return users.ToList
            End Function
    
            Public Function GetUserByID(ByVal id As Integer) As User Implements IUserRepository.GetUserByID
                Dim viewUser = (From u In dc.Users
                           Where u.ID = id
                           Select u).FirstOrDefault
                Return viewUser
            End Function
    
        End Class
    #End Region
    End Namespace
