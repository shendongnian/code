     Protected Overrides Sub InitializeDataCell(ByVal cell As
     System.Web.UI.WebControls.DataControlFieldCell, 
     ByVal rowState As System.Web.UI.WebControls.DataControlRowState)
        ... ect...
                    AddHandler cell.DataBinding, AddressOf OnDataBindField
        
                End Sub
