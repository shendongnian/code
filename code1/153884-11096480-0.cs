    SAPbouiCOM.EditText EditValue;
    string strValue;
    String ColUId = "col_1"  // Column UID
    Int32 Row     = 1        //Row Number
    Item item     = form.Items.Item("38");
    Matrix matrix = ((Matrix)(item.Specific));
    EditValue     = (SAPbouiCOM.EditText)matrix.GetCellSpecific(ColUId, Row );
    strValue      = Edit.Value.ToString().Trim();
