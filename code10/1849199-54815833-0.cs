    System.Web.UI.HtmlControls.HtmlInputHidden  hiddenElement = new System.Web.UI.HtmlControls.HtmlInputHidden();
    hiddenElement.Id={IDforthisField};
    hiddenElement.Value = dataStr;  // <--------- Assign the value here
    
    newDiv.Controls.Add(hiddenElement); // <--- Then add to the div element 
    `  
