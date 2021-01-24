    var query = from a in context.A
                join b1 in context.B
                    on new { Perimeter = a.level1, LevelID = 1 }
                    equals new { Perimeter = b1.PerimeterID, LevelID = b1.PerimeterLevelID }
                join b2 in context.B
                    on new { Perimeter = a.level2, LevelID = 2 }
                    equals new { Perimeter = b2.PerimeterID, LevelID = b2.PerimeterLevelID }
                join b3 in context.B
                    on new { Perimeter = a.level3, LevelID = 3 }
                    equals new { Perimeter = b3.PerimeterID, LevelID = b3.PerimeterLevelID }
                select new
                {
                    a,
                    b1,
                    b2,
                    b3
                };
