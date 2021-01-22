        // A sample dictionary:
        var dictionary = new Dictionary<int, string>();
        dictionary.Add(1, "Home");
        dictionary.Add(2, "Work");
        dictionary.Add(3, "Mobile");
        dictionary.Add(4, "Fax");
        // Binding the dictionary to the DropDownList:
        dropDown.DataTextField = "Value";
        dropDown.DataValueField = "Key";
        dropDown.DataSource = dictionary;  //Dictionary<int, string>
        dropDown.DataBind();
