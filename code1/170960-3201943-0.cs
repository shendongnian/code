    /* This ViewModel is to serve UserControlHotelDescription */
    public class HotelDescriptionModelView 
    {
        HotelDescription _hotelDescriptionModel;
        public ObservableCollection<CheckableFacility> CheckableRoomFacilities { get; set; }
    
        public HotelDescriptionModelView()
        {
            _hotelDescriptionModel = new HotelDescription();
            CheckableRoomFacilities = new ObservableCollection(GetCheckableFacilities(FacilityType.Room)); 
        }
        
        IEnumerable<CheckableFacility> GetCheckableFacilities(FacilityType type)
        {
            return (
                        from fl in AvailableFacilities.Where(af => af.FacilityType == type)
                                                      .Union(RoomFacilities) 
                        group fl by fl.Name into d 
                        select new CheckableFacility() 
                        { 
                            Name = d.Key, 
                            IsChecked = (d.Count() > 1) 
                        }
                    );
        }
    }
    
