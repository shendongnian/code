       // Get User ID
        int user_id;
        
        try {
            user_id = int.Parse(context.Session["user_id"].ToString());
        } catch {
            WriteErrorObject(context,"Could not find required user in the session.");
            return;
        }
    
        // Get Query
        string query;
        
        try {
            query = context.Request.QueryString["query"];
            
            if (String.IsNullOrEmpty(query)) throw new Exception();
        } catch {
            query = "";
        }
        
        // Get Revision
        int revision;
        
        try {
            revision = int.Parse(ConfigurationManager.AppSettings["reportingRevision"]);
        } catch {
            revision = -1;   
        }
        
        // Check for our connection string
        try {
            if (ConfigurationManager.ConnectionStrings["reportInstance"] == null) throw new Exception(); 
        } catch {
            WriteErrorObject(context,"Cannot find the database connection string.");
            return;
        }
        
        // Get our connection string
        string connectionstring = ConfigurationManager.ConnectionStrings["reportInstance"].ConnectionString;
        
        // Create our sproc caller
        StoredProc proc;
        
        try {
            proc = new StoredProc("usp_rep2_agency_list",connectionstring,30);
        } catch (Exception ex) {
            WriteErrorObject(context,"There was an exception creating the stored procedure caller: " + ex.Message);
            return;
        }
        
        // Set up sproc
        if (revision != -1) proc.AddParameter("@revision",revision,SqlDbType.Int);
        
        proc.AddParameter("@user_id",user_id,SqlDbType.Int);
            
        if (query != null && query.Length > 0) proc.AddParameter("@query",query,SqlDbType.NVarChar);
        
        // Execute sproc
        DataSet results;
        
        try {
            results = (DataSet)proc.Execute(StoredProc.ExecuteTypes.ReturnDataset);
        } catch (Exception ex) {
            WriteErrorObject(context,"There was an exception calling the stored procedure: " + ex.Message);
            return;   
        }
        
        // Check we have results
        if (results == null) {
            WriteErrorObject(context,"There was no dataset returned from the stored procedure.");
            return;   
        }
        
        // Check we have a table
        if (results.Tables.Count < 1) {
            WriteErrorObject(context,"There was no tables found in the returned dataset from the stored procedure.");
            return;   
        }
        
        // Get the table
        DataTable table = results.Tables[0];
        
        // Begin JSON
        StringWriter writer = new StringWriter();
        JsonWriter json = new JsonWriter(writer);
        
        json.WriteStartObject();
        json.WritePropertyName("success");
        json.WriteValue(true);
        json.WritePropertyName("count");
        json.WriteValue(table.Rows.Count);
        json.WritePropertyName("list");
        json.WriteStartArray();
        
        // Process table rows
        for (int i = 0; i < table.Rows.Count; i++) {
            // Get row
            DataRow row = table.Rows[i];
            
            // ID
            if (row["agency_id"] == null || row["agency_id"] == DBNull.Value) {
                WriteErrorObject(context,"There was an error processing the agency id value from row " + i.ToString() + ".");
                return;
            }
            
            int agency_id;
            
            if (!int.TryParse(row["agency_id"].ToString(),out agency_id)) {
                WriteErrorObject(context,"Could not parse the agency id value from row " + i.ToString() + ".");
                return;   
            }
            
            // Name
            if (row["agency_name"] == null || row["agency_name"] == DBNull.Value) {
                WriteErrorObject(context,"There was an error processing the agency name value from row " + i.ToString() + ".");
                return;   
            }
            
            string agency_name = row["agency_name"].ToString();
            
            // Write out JSON for this row
            json.WriteStartObject();
            json.WritePropertyName("agency_id");
            json.WriteValue(agency_id);
            json.WritePropertyName("agency_name");
            json.WriteValue(agency_name);
            json.WritePropertyName("icon");
            json.WriteValue("iq-reporting-dropdowns-agency");
            json.WriteEndObject();
        }
        
        // End JSON
        json.WriteEndArray();
        json.WriteEndObject();
        
        string text = writer.GetStringBuilder().ToString();
        
        context.Response.Write(text);
        context.Response.Flush();
