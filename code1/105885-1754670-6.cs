    using System.Collections.Generic;
    var selectedIndices = lstCategory.GetSelectedIndices();
    var killList = new List<ListItem>();
    foreach (var selIndex in selectedIndices)
    {
        //add the item to remove to the kill list AND to the other listbox
        killList.Add(lstCategory.Items[selIndex]);
        lstSelCategory.Items.Add(lstCategory.Items[selIndex]);
    }
    foreach (var killMe in killList)
    {
        lstCategory.Items.Remove(killMe);
    }
