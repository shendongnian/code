    var classRooms = from c in context.ClassRooms
                     group c by new {c.ClassRoomNo}
                     from room in c
                     select new {
                        Title = room.First().ClassRoomTitle,
                        NoSessions = room.Count(),
                        Teachers = from cr in room
                                   group cr by new {cr.TeacherName} into t
                                   select new {
                                       Teacher = t.Key,
                                       NoSessions = t.Count()
                                   }
                     };
