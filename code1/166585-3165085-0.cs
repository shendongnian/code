            var vGroup = from p in ClassRoom
                         group p by new { p.ClassRoomNo, p.TeacherName }
                             into g
                             from i in g
                             select new
                             {
                                 i.ClassRoomNo,
                                 i.TeacherName,
                                 i.ClassRoomTitle,
                                 NoSessionsPerTeacher = g.Count()
                             };
            var pGroup = from p in vGroup
                         group p by new { p.ClassRoomNo }
                             into g
                             from i in g
                             select new
                             {
                                 i.ClassRoomTitle,
                                 NoSessionsPerRoom = g.Count(),
                                 i.TeacherName,
                                 i.NoSessionsPerTeacher
                             };
            var result = pGroup.OrderBy(p => p.ClassRoomNo).ThenBy(p => p.TeacherName);
