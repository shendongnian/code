    string FieldName = Application.ActiveSelection.FieldNameList[1];
    if (sel.Tasks != null)
    {
        task = sel.Tasks[1];
        long projectField = FieldNameToFieldConstant(FieldName, pjProject);
        string value = task.GetField(projectField);
    }
