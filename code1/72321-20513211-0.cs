    OLEObjects objs = worksheet.OLEObjects();
    OLEObject obj = objs.Add("Forms.CheckBox.1", System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value, cell.Left + 1, cell.Top + 1, cell.Width - 2, cell.Height - 2);
    obj.Object.Caption = "";
    if (text == "TRUE")
    {
    	obj.Object.value = true;
    }
    else
    {
    	obj.Object.value = false;
    }
