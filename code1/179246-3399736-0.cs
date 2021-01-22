    Repeater collectorData = (Repeater)item.FindControl("CollectedTableRepeater1");
    Repeater contactedData = (Repeater)item.FindControl("ContactedTableRepeater2");
    if( collectedDocuments.Tables[0].Rows.Count > 0 ){
            //if there is data(more than 0 rows), bind it
            collectorData.DataSource = collectedDocuments;
            collectorData.DataBind();
            
            contactedData.DataSource = contactedDocuments;
            contactedData.DataBind();
    } else {
            collectorData.Visible = False;
            //optional display "No data found" message
            contactedData.Visible = False;
    }
