    var results = courseCounts
         .GroupBy(cc => (cc.Course, cc.Class))
         .Select(grp => new 
                 {
                     Course = grp.Key.Course,
                     Class = grp.Key.Class,
                     Male = grp.Where(x => x.Sex == "M").Count(),
                     Female = grp.Where(x => x.Sex == "F").Count(),
                 });
