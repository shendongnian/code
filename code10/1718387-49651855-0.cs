              public string makeclassandfunctions(string tablename)
        {
            DataSet ds = loadtabledata(tablename);
            //the class starts frome here
            string classoftable = "</br></br></br>public class   " + tablename + "</br>{   " + "</br>";
          
            for (int a = 0; a <= ds.Tables[0].Columns.Count-1 ; a++)
            {
                if (ds.Tables[0].Columns[a].ColumnName.Contains("ID"))
                {
                    classoftable += "public Int32 " + ds.Tables[0].Columns[a].ColumnName + "{get;set;}" + "</br>";
                }
                else
                {
                    classoftable += "public string   " + ds.Tables[0].Columns[a].ColumnName + "{get;set;}" + "</br>";
                }
            }
            //class is ending here its variables are defined here
            classoftable += "} ";
            //the insertion function starts frome here 
            classoftable += "</br>public void insertinto" + tablename + "(" + tablename + "  obj" + tablename + ")</br>{ </br> ";
            classoftable += " sqlcon.Open();</br> SqlCommand cmd = new SqlCommand(" + @""" insert into " + tablename + " values " + "(";
            for (int a = 1; a <= ds.Tables[0].Columns.Count - 1; a++)
            {
                if (a == ds.Tables[0].Columns.Count - 1)
                {
                    classoftable += "@" + ds.Tables[0].Columns[a].ColumnName;
                }
                else
                {
                    classoftable += "@" + ds.Tables[0].Columns[a].ColumnName + " , ";
                }
            }
            classoftable += ")" + @""",sqlcon);</br>";
            for (int a = 1; a <= ds.Tables[0].Columns.Count - 1; a++)
            {
                classoftable += "cmd.Parameters.AddWithValue (" + @"""@" + ds.Tables[0].Columns[a].ColumnName + @""" ,obj" + tablename + "." + ds.Tables[0].Columns[a].ColumnName + ");</br>";
            }
            classoftable += " cmd.ExecuteNonQuery();</br>sqlcon.Close();";
            classoftable += "}</br></br>";
            //insert function ends here
            //delete function startsfrome here
            classoftable += "public void deletefrom" + tablename + "(" + "Int32 id" + ")" + "</br>{ </br> ";
            classoftable += " sqlcon.Open();</br> SqlCommand cmd = new SqlCommand(" + @""" delete  from [" + tablename + "]" + "  where " + ds.Tables[0].Columns[0].ColumnName + "= " + @"'" + @"""" + "+id+" + @"""" + @"'" + @"""" + ",sqlcon);" + "</br> cmd.ExecuteNonQuery();</br>sqlcon.Close();</br>}</br></br>";
            //delete ends here
            //updatefunctionstarts frome here
            classoftable += "public void update" + tablename + "(" + tablename + "  obj" + tablename + " )</br>{";
            classoftable += " sqlcon.Open();</br> SqlCommand cmd = new SqlCommand(" + @""" update  [" + tablename + "] set  ";
            for (int a = 1; a <= ds.Tables[0].Columns.Count - 1; a++)
            {
                string columnname = ds.Tables[0].Columns[a].ColumnName;
                if (a == ds.Tables[0].Columns.Count - 1)
                {
                    classoftable += columnname + " = @" + columnname + "  ";
                    classoftable += "where  " + ds.Tables[0].Columns[0].ColumnName + " = @" + ds.Tables[0].Columns[0].ColumnName;
                }
                else
                {
                    classoftable += columnname + " = @" + columnname + " , ";
                }
            }
            classoftable += @"""" + ",sqlcon);</br>";
            for (int a = 0; a <= ds.Tables[0].Columns.Count - 1; a++)
            {
                classoftable += "cmd.Parameters.AddWithValue (" + @"""@" + ds.Tables[0].Columns[a].ColumnName + @""" ,obj" + tablename + "." + ds.Tables[0].Columns[a].ColumnName + ");</br>";
            }
            classoftable += "cmd.ExecuteNonQuery();</br>sqlcon.Close();</br>}</br>";
            //updatesstatementfunction ends here
           
            return classoftable;
        }
