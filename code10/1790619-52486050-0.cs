    <dx:ASPxGridView ... OnCustomColumnDisplayText="OnCustomColumnDisplayText">
        <Columns>
    	    ...
            <dx:GridViewDataSpinEditColumn FieldName="FOO_STATUS">
                <Settings FilterMode="DisplayText" />
            </dx:GridViewDataSpinEditColumn>
        </Columns>
    </dx:ASPxGridView>
    protected void OnCustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e) {
        if (e.Column.FieldName == "FOO_STATUS") {
            e.DisplayText = STATUS[int.Parse(e.GetFieldValue("FOO_STATUS").ToString())];
        }
    }
