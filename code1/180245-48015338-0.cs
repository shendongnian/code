    <Extension()>
    Public Function [GetControls](Of T As Control)(
        ByVal Parent As Control) As IEnumerable(Of Control)
        Dim oControls As IEnumerable(Of Control) = Parent.Controls.Cast(Of Control)()
        Return oControls.SelectMany(Function(c) GetControls(Of T)(c)).Concat(oControls).Where(Function(c) c.GetType() Is GetType(T))
    End Function
