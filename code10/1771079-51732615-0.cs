    var deplTable = ThisSheet.Evaluate("DeploymentTable");
    
    if (deplTable.ListObject.ListRows.Count > 1)
        {
            do deplTable.ListObject.ListRows[2].Delete();
                while (deplTable.ListObject.ListRows.Count > 1);
        }
