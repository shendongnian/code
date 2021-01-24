    List<CheckBox> checkbox_list = new List<CheckBox>();
    //proceed to manually add all checkboxes to this list upon program initialization
    checkbox_list.Add(checkbox1);
    //...
    //so on until you are done
    bool check = false; //we are looking for at least one true, so start with false
    for(int i = 0; i < checkbox_list.Count; i++)
    {
        if(checkbox_list[i].Checked == true)
            check = true;
    }
    if(check == true)
        Console.WriteLine("At least one checkbox is checked.");
    else
        Console.WriteLine("No checkboxes checked.");
    //use "check" bool to determine whether to update
