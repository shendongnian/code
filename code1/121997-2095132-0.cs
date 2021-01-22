    ' ** use FindControl if instead a databound event, otherwise you could skip.
    Dim plcControlHolder as PlaceHolder = e.Row.FindControl("plcControlHolder") 
    Dim btnDynamic As New Button
    btnDynamic.Id = "MyButton"
    plcControlHolder.Controls.Add(btnDynamic)
