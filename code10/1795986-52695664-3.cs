    PTI.ModifyCollection(
          selectedPredicate:(s) => s.Name == name,
          selectedAction:(s) => 
               { 
                 s.IsSelected = true; 
                 App.DB.UpdateIntSetting(SET.Pti, setting.Id); 
               },
          othersAction:(s) => s.IsSelected = false);
