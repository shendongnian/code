    SPListCollection collLists = oWeb.Lists; //Get All lists
    foreach (SPList oList in collLists)
    {
       if (oList.BaseType == SPBaseType.DocumentLibrary) //Serach for all Libraries
       {
          SPDocumentLibrary oDocumentLibrary = (SPDocumentLibrary)oList;
          string name = oDocumentLibrary.Title.ToString();
          
          if (name == "LibraryName") //Get library what you need
          {
             SPListItem row = oDocumentLibrary.Items[i]; //get an element by id in library
             SPFieldLookupValue newValue = new SPFieldLookupValue( id , "LookupFieldValue");
             row["field_name"] = newValue; 
