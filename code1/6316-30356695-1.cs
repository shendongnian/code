    Public Class CountryDropDownList
        Inherits System.Web.UI.UserControl
        Public Event SelectedCountryChanged As EventHandler
    
        Protected Sub ddlCountryList_SelectedIndexChanged(sender As Object, e As EventArgs)
            ' bubble the event up to the parent
            RaiseEvent SelectedCountryChanged(Me, e)
        End Sub
    End Class
