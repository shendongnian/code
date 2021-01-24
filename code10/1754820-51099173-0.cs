    Public MustInherit Class AnimalViewModel
        Inherits GalaSoft.MvvmLight.ViewModelBase
        Public Property Animal As Animal
        Protected Sub New(NewAnimal As Animal)
            Me.Animal = NewAnimal
        End Sub
        Public Overrides Function ToString() As String
            Return String.Format("{1}{2} ""{3}"" | {4}",
                                 Me.Animal.RightEarTag,
                                 Me.Animal.LeftEarTag,
                                 Me.Animal.ShortName,
                                 Me.SexIdentifierName)
        End Function
        Public MustOverride Function SexIdentifierName() As String
    End Class
    Public Class MaleViewModel
        Inherits AnimalViewModel
        Public Sub New(AnAnimal As Male)
            MyBase.New(AnAnimal)
        End Sub
        Public Overrides Function SexIdentifierName() As String
            Return "Male"
        End Function
    End Class
