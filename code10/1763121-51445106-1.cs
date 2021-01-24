    // this gets the data object and sets ti to a data table
                OleDbDataAdapter A = new OleDbDataAdapter();
                System.Data.DataTable dt = new System.Data.DataTable();
                A.Fill(dt, Dts.Variables["User::SSISObjectVariableFromPackage"].Value);
    
                // for test data
                DataTable sourceTable = dt;
                //Now loop through databale and do your processing
    //----------------------------------------------------------------------
    //Updated  -- possible solution to fix issue in comments but left original above as that works for most 
    
    //try this version instead, mabye converting the SSIS variable to a C# object first, and not accessing it directly into the A.Fill may resolve your issue in the comments:
    
    Object OBJDataTableValidFieldListFull = Dts.Variables["User::SSISObjectVariableFromPackage"].Value;
    
        // this gets the data object and sets ti to a data table
                    OleDbDataAdapter A = new OleDbDataAdapter();
                    System.Data.DataTable dt = new System.Data.DataTable();
                    A.Fill(dt, OBJDataTableValidFieldListFull);
        
                    // for test data
                    DataTable sourceTable = dt;
    
                    //Now loop through databale and do your processing
