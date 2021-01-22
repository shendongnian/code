    //create an unordered list
    HtmlGenericControl myList = new HtmlGenericControl("ul");
    
    //create the list item
    HtmlGenericControl myListItem = new HtmlGenericControl("li");
    myListItem.InnerText = "A"; //you can get/set the li item contents using this property
    
    //set the class here
    myListItem.Attributes["class"] = "someClassName";
    //add the list item to the list, and the list to the control set of your page, usercontrol,etc.
    myList.Controls.Add(myListItem);
    this.Controls.Add(myList);
    
