                    foreach(var item in VehiculesList)
            {
                item.VehicleLocation.Lat_String = item.VehicleLocation.Latitude.ToString().Replace(",", ".");
                item.VehicleLocation.Long_String = item.VehicleLocation.Longitude.ToString().Replace(",", ".");
            }
