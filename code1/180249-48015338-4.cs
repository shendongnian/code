    ''' <summary>Collects child controls of the specified type or base type within the passed control.</summary>
    ''' <typeparam name="T">The type of child controls to include. Restricted to objects of type Control.</typeparam>
    ''' <param name="Parent">Required. The parent form control.</param>
    ''' <returns>An object of type IEnumerable(Of T) containing the control collection.</returns>
    ''' <remarks>This method recursively calls itself passing child controls as the parent control.</remarks>
    <Extension()>
    Public Function [GetControls](Of T As Control)(
        ByVal Parent As Control) As IEnumerable(Of T)
        Dim oControls As IEnumerable(Of Control) = Parent.Controls.Cast(Of Control)()
        Return oControls.SelectMany(Function(c) GetControls(Of T)(c)).Concat(oControls.Where(Function(c) c.GetType() Is GetType(T) Or c.GetType().BaseType Is GetType(T))
    End Function
