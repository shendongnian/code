    Interface Icontrol
     ' Declare an interface.
     Property MustHave() As String
     
    End Interface
     
    Then in your user control include
     Public Class mycontrol
     Inherits System.Web.UI.UserControl
     Implements Icontrol
     
    It makes this propery required
