    Namespace Data
    
    #Region "Interface"
        Public Interface IUserService
            Function GetAllUsers() As IList(Of User)
            Function GetUserByID(ByVal id As Integer) As User
        End Interface
    #End Region
    
    
    #Region "Service"
        Public Class UserService : Implements IUserService
    
            Private _ValidationDictionary As IValidationDictionary
            Private _UserRepository As IUserRepository
    
            Public Sub New(ByVal validationDictionary As IValidationDictionary, ByVal UserRepository As IUserRepository)
                _ValidationDictionary = validationDictionary
                _UserRepository = UserRepository
            End Sub
    
            Public Function GetAllUsers() As System.Collections.Generic.IList(Of User) Implements IUserService.GetAllUsers
                Return _UserRepository.GetAllUsers
            End Function
    
    
            Public Function GetUserByID(ByVal id As Integer) As User Implements IUserService.GetUserByID
                Return _UserRepository.GetUserByID(id)
            End Function
    
        End Class
    #End Region
    End Namespace
