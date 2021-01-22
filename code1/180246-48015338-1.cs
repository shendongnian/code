    ''' <summary>Collects all the controls of the specified type within the passed control.</summary>
    ''' <param name="Parent">Required. The parent form control.</param>
    ''' <returns>An object of type IEnumerable containing the control collection.</returns>
    ''' <remarks>This method recursively calls itself passing child controls as the parent control.</remarks>
    <Extension()>
    Public Function [GetControls](Of T As Control)(
        ByVal Parent As Control) As IEnumerable(Of T)
        Dim oControls As IEnumerable(Of Control) = Parent.Controls.Cast(Of Control)()
        Return oControls.SelectMany(Function(c) GetControls(Of T)(c)).Concat(oControls.Where(Function(c) c.GetType() Is GetType(T)).Cast(Of T)())
    End Function
