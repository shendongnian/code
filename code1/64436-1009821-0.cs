    SPList list = web.Lists["My List Name"];
    SPView view = list.Views["My View Name"];  // This view would define Postion > 0
    SPQuery query = new SPQuery(view);
    SPListItemCollection items = list.GetItems(query);
    // Iterate through results and generate XML
