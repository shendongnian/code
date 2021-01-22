    'Base namespace "EnumConstraint"
    Imports Enums = EnumConstraint.Enums(Of System.Enum)
    Public NotInheritable Class Enums(Of Temp As Class)
    Private Sub New()
    End Sub
    Public Shared Function Parse(Of TEnum As {Temp, Structure})(ByVal Name As String) As TEnum
        Return DirectCast([Enum].Parse(GetType(TEnum), Name), TEnum)
    End Function
    Public Shared Function IsDefined(Of TEnum As {Temp, Structure})(ByVal Value As TEnum) As Boolean
        Return [Enum].IsDefined(GetType(TEnum), Value)
    End Function
    Public Shared Function HasFlags(Of TEnum As {Temp, Structure})(ByVal Value As TEnum, ByVal Flags As TEnum) As Boolean
        Dim flags64 As Long = Convert.ToInt64(Flags)
        Return (Convert.ToInt64(Value) And flags64) = flags64
    End Function
    End Class
    Module Module1
    Sub Main()
        Dim k = Enums.Parse(Of DateTimeKind)("Local")
        Console.WriteLine("{0} = {1}", k, CInt(k))
        Console.WriteLine("IsDefined({0}) = {1}", k, Enums.IsDefined(k))
        k = DirectCast(k * 2, DateTimeKind)
        Console.WriteLine("IsDefined({0}) = {1}", k, Enums.IsDefined(k))
        Console.WriteLine(" {0} same as {1} Or {2}: {3} ", IO.FileAccess.ReadWrite, IO.FileAccess.Read, IO.FileAccess.Write, _
                          Enums.HasFlags(IO.FileAccess.ReadWrite, IO.FileAccess.Read Or IO.FileAccess.Write))
        ' These fail to compile as expected:
        'Console.WriteLine(Enums.HasFlags(IO.FileAccess.ReadWrite, IO.FileOptions.RandomAccess))
        'Console.WriteLine(Enums.HasFlags(Of IO.FileAccess)(IO.FileAccess.ReadWrite, IO.FileOptions.RandomAccess))
        If Debugger.IsAttached Then _
            Console.ReadLine()
    End Sub
    End Module
