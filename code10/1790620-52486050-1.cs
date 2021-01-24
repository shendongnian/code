    <dx:ASPxGridView ... OnCustomColumnDisplayText="OnCustomColumnDisplayText">
        <Columns>
    	    ...
            <dx:GridViewDataSpinEditColumn FieldName="FOO_STATUS">
                <Settings FilterMode="DisplayText" />
            </dx:GridViewDataSpinEditColumn>
        </Columns>
    </dx:ASPxGridView>
    //CS    
    protected void OnCustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e) {
        if (e.Column.FieldName == "FOO_STATUS") {
            e.DisplayText = STATUS[int.Parse(e.GetFieldValue("FOO_STATUS").ToString())];
        }
    }
    'VB
    Protected Sub OnCustomColumnDisplayText(ByVal sender As Object, ByVal e As ASPxGridViewColumnDisplayTextEventArgs)
        If e.Column.FieldName Is "FOO_STATUS" Then
            e.DisplayText = STATUS(Integer.Parse(e.GetFieldValue("FOO_STATUS").ToString()))
        End If
    End Sub
