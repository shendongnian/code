    public static System.Collections.ArrayList getTableMethods(str _tableName)
    {
        SysDictTable sdt;
        TreeNode tn;
        TableId tableId;
        MethodInfo methodInfo;
        System.Collections.ArrayList methodArr;
        #AOT
        ;
        
        tableId = tableName2id(_tableName);
    
        sdt = SysDictTable::newTableId(tableid);
    
        methodArr = new System.Collections.ArrayList();
        tn = TreeNode::findNode(#TablesPath + "\\" + _tableName + "\\" + "Methods");
        tn = tn.AOTfirstChild();
        while(tn)
        {
            methodArr.Add(tn.AOTname());
            tn = tn.AOTnextSibling();
        }
        
        return methodArr;
    }
