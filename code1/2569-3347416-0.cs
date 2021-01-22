      protected void LinqDataSource1_Selecting(object sender, LinqDataSourceStatusEventArgs e)
            {
               System.Collections.Generic.List<country> lst  = e.Result as System.Collections.Generic.List<country>;
    
               int count = lst.Count;
            }
