    object newList = null; // Use object. Grid datasource accepts object
    switch (ddlDiseases.SelectedValue)
    {
        case DiseasesCollections.LSD:
             newList = ImportExcleInfoList.Select(x => new
             {
                  x.GAA, x.GAAratio, x.GAAInhibition, x.GAAStatus,
                  x.FAB, x.FABratio, x.FABStatus,
                  x.GD, x.GDratio
               }).ToList();
    
               break;
    
          case DiseasesCollections.MPS:
               newList = ImportExcleInfoList.Select(x => new
               {
                 x.MPS2, x.MPS2ratio, x.MPS2Status,
                 x.MPS3B, x.MPS3Bratio, x.MPS3BStatus
               }).ToList();
    
               break;
               }
    
         //****** case DiseasesCollections.Other...
    gvAdvanced.DataSource = newList; //Set new list here instead on every case.
    gvAdvanced.DataBind();
