    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       If Page.IsPostBack Then
          Dim lb as ListButton = TryCast(Page.FindControl("IDOfControl"), LinkButton)
          lb.Click += new EventHandler(showModalPopup);
       End If
    End Sub
