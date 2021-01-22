public static bool CreateAXTable(this Axapta ax)
{
    string TableName = "MyCustomTable"; 
    string size = "255"; //You could load this from a setting
    bool val = false;
    if (!ax.TableExists(TableName))
    {
        AxaptaObject TablesNode = (AxaptaObject)ax.CallStaticClassMethod("TreeNode", "findNode", @"\Data Dictionary\Tables");
        AxaptaObject node;
        AxaptaObject fields;
        AxaptaObject fieldNode;
        TablesNode.Call("AOTadd", TableName); 
        node = (AxaptaObject)ax.CallStaticClassMethod("TreeNode", "findNode", "\\Data dictionary\\Tables\\" + TableName);        
        fields = (AxaptaObject)ax.CallStaticClassMethod("TreeNode", "findNode", "\\Data dictionary\\Tables\\" + TableName + "\\Fields");
        fields.Call("addString", "String1"); //add a string field
        fieldNode = (AxaptaObject)fields.Call("AOTfindChild", "String1"); //grab a reference to the field
        fieldNode.Call("AOTsetProperty", "StringSize", size);
        fieldNode.Call("AOTsave");
        fields.Call("addString", "String2"); //add a string field
        fieldNode = (AxaptaObject)fields.Call("AOTfindChild", "String2"); //grab a reference to the field
        fieldNode.Call("AOTsetProperty", "StringSize", size);
        fieldNode.Call("AOTsave");
        fields.Call("addString", "String3"); //add a string field
        fieldNode = (AxaptaObject)fields.Call("AOTfindChild", "String3"); //grab a reference to the field
        fieldNode.Call("AOTsetProperty", "StringSize", size);
        fieldNode.Call("AOTsave");
        fields.Call("addString", "String4"); //add a string field
        fieldNode = (AxaptaObject)fields.Call("AOTfindChild", "String4"); //grab a reference to the field
        fieldNode.Call("AOTsetProperty", "StringSize", size);
        fieldNode.Call("AOTsave");
        fields.Call("addReal", "Real1");
        fields.Call("addReal", "Real2");
        fields.Call("addReal", "Real3");
        fields.Call("addReal", "Real4");
        fields.Call("addDate", "Date1");
        fields.Call("addDate", "Date2");
        fields.Call("addDate", "Date3");
        fields.Call("addDate", "Date4");
        fields.Call("AOTsave");
        node.Call("AOTsave");
        AxaptaObject appl = ax.GetObject("appl");
        appl.Call("dbSynchronize", Convert.ToInt32(node.Call("applObjectId")), false);
        val = true;
    }
    else //Table already exists
    {
        val = true;
    }
    return val;
}
public static bool TableExists(this Axapta ax, string tableName)
{
    return ((int)ax.CallStaticClassMethod("Global", "tableName2Id", tableName) > 0);
}
