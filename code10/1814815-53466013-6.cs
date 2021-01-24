    DateTime StartDateWantToBook = Convert.ToDateTime(dateTimePicker1.Value.ToString());
    DateTime EndDateWantToBook = Convert.ToDateTime(dateTimePicker2.Value.ToString());
    var AllRooms = (from u in db.Room join b in db.Reservation on u.RoomId equals b.RoomId join f in db.Floor on u.FloorId equals f.FloorId join ty in db.RoomType on u.RoomTypeId equals ty.RoomTypeId select new {
     RomId = b.RoomId,
      Floor = f.FloorName,
      RommsNr = u.RumNummer,
      Room_Type = ty.AmountRomms
      // But Here by somehow I think I have to run
      // another Linq query to filter RoomsId and show only those who do not exists in Reservation table.                              
    }).ToList();
    
    var ReservedRooms = (from u in db.Room join b in db.Reservation on u.RoomId equals b.RoomId join f in db.Floor on u.FloorId equals f.FloorId join ty in db.RoomType on u.RoomTypeId equals ty.RoomTypeId where StartDateWantToBook <= b.EndDate && b.StartDate <= EndDateWantToBook select new {
     RomId = b.RoomId,
      Floor = f.FloorName,
      RommsNr = u.RumNummer,
      Room_Type = ty.AmountRomms
      // But Here by somehow I think I have to run
      // another Linq query to filter RoomsId and show only those who do not exists in Reservation table.
    
    }).ToList();
    
    var result = AllRoom.Except(ReservedRooms);
    dataGridView1.DataSource = ReservedRooms;
