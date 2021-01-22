     List<SelectListItem> roomTypesSelect = new List<SelectListItem>();
        
        IList roomTypes = RoomTypeManager.GetAllRoomTypes();
        RoomTypes currentRoomType = RoomTypeManager.GetCurrentRoomType();
        bool isSelected = false;
        foreach (RoomTypes roomTypes in roomTypes)
        {
        if (currentRoomType.Id == roomTypes.Id)
           isSelected = true;
        else
            isSelected = false;
        
        roomTypes.Add(new SelectListItem { Text = roomTypes.Name + " " +roomTypes.ColourCode, Value = roomTypes.Id, Selected = isSelected });
        }
        
        ViewData["RoomTypes"] = roomTypes;
