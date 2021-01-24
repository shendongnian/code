    stVM = db.Cargo
             .Include( c => c.Vehicle )
             .Include( c => c.Company )
           .Where( c => !c.Isdeleted && c.IsActive )
           .AsEnumerable()
           .Select( c => new CargoRequestVM
           {
             CargoId = c.CargoID,
             CompanyName = c.Company.CompanyName,
             VehicleNo = c.Vehicle.VehicleNo,
             Date = c.DateOfPassage,
             Type = CargoElements.CargoTypeName(c.Type.ToString())                                       
           }).ToList();
