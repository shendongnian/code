      Public Class DblClickTreeview
        Inherits TreeView
        Private _SupressExpColl As Boolean = False
        Private _LastClick As DateTime = Now
        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            _SupressExpColl = Now.Subtract(_LastClick).TotalMilliseconds <= SystemInformation.DoubleClickTime
            _LastClick = Now
            MyBase.OnMouseDown(e)
        End Sub
        Protected Overrides Sub OnBeforeCollapse(e As TreeViewCancelEventArgs)
            e.Cancel = _SupressExpColl
            MyBase.OnBeforeCollapse(e)
        End Sub
        Protected Overrides Sub OnBeforeExpand(e As TreeViewCancelEventArgs)
            e.Cancel = _SupressExpColl
            MyBase.OnBeforeExpand(e)
        End Sub
    End Class
