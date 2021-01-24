    if (!string.IsNullOrEmpty(model.CarPartName) && !string.IsNullOrEmpty(model.CarPartCode)) {
        query = from c in query
            join parts in db.CAR_PARTS on c.ID equals parts.CarID
            where parts.PartName == model.CarPartName || parts.PartCode == model.CarPartCode
            select c;
    } else if (!string.IsNullOrEmpty(model.CarPartName)) {
        query = from c in query
            join parts in db.CAR_PARTS on c.ID equals parts.CarID
            where parts.PartName == model.CarPartName
            select c;    
    } else if (!string.IsNullOrEmpty(model.CarPartCode)) {
        query = from c in query
            join parts in db.CAR_PARTS on c.ID equals parts.CarID
            where parts.PartCode == model.CarPartCode
            select c;    
    }
