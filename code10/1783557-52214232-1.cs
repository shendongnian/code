    //    item["monitorname"] = Convert.ToString(dm["monitorname"]);
    //}
    
    if(dm.ContainsKey(“monitorname”))
    {
       item["monitorname"] = Convert.ToString(dm["monitorname"]);
    }
    else
    {
        // add code taking care of item["monitorname"] when dm dictionary does not have “monitorname”
    }
