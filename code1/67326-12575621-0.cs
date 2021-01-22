    Public Class MyListView : Inherits System.Windows.Forms.ListView
    Public Sub New()
        MyBase.New()
        MyBase.OwnerDraw = True
    End Sub
    Protected Overrides Sub OnDrawSubItem(ByVal e As DrawListViewSubItemEventArgs)
        If x Then ' condition to determine if you want to draw this subitem
            ' draw code goes here
        Else
            e.DrawDefault = True
        End If
        MyBase.OnDrawSubItem(e)
    End Sub
    Protected Overrides Sub OnDrawColumnHeader(ByVal e As DrawListViewColumnHeaderEventArgs)
        e.DrawDefault = True
        MyBase.OnDrawColumnHeader(e)
    End Sub
    Protected Overrides Sub OnDrawItem(e As System.Windows.Forms.DrawListViewItemEventArgs)
        e.DrawDefault = True
        MyBase.OnDrawItem(e)
    End Sub
    End Class
