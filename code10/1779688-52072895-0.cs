     private void loadingData()
       {
           this.makeConnection();
    
           Console.WriteLine("\nBegin loading data...");
    
           try
           {
               OracleCommand command = new OracleCommand("SELECT DISTINCT t1.ITM_CD, t1.ITM_NM, t1.UNIT_CD, t1.PCKG_UNIT_QTY, t1.PCKG_UNIT_CD, t1.MAIN_INP_CD, t1.HS_CD, t1.EXT_ITM_NM, t1.CTG_A, t1.CTG_B, t1.CTG_C, t1.CTG_D ,t1.CTG_E, t1.RMRKS02, t1.FLEX_NUM01, t1.FLEX_NUM03, t1.FLEX_NUM04, t1.FLEX_NUM05, T2.UNIT_WT, T3.C_INPT_QTY, T3.C_REQ_QTY, T3.P_REQ_QTY, T4.BOM_PTN, T4.PROD_LOC_CD FROM CM_HINMO_ALL t1 INNER JOIN CM_ITM_UNIT_ALL T2 ON T1.ITM_CD = T2.ITM_CD AND T1.UNIT_CD = T2.UNIT_CD LEFT JOIN SM_BOM_ALL T3 ON T1.ITM_CD = T3.P_ITM_CD LEFT JOIN SM_HINMOS_ALL T4 ON T1.ITM_CD = T4.ITM_CD WHERE 0=0 AND T3.BOM_PTN IN (1,2,3,4) ORDER BY ITM_CD", connection);
               OracleDataAdapter adapter = new OracleDataAdapter(command);
               DataTable table = new DataTable();
    
               adapter.Fill(table);
    
               dataGridView1.DataSource = table;
               
               dataGridView1.DataBind();
    
               Console.WriteLine("Success loading data...");
    
               this.closeConnection();
    
           }
           catch (Exception ex)
           {
               Console.WriteLine("Failed to load data :: " + ex.Message);
           }
       }
