    var hours = from tr in db.TimeRecords
                where !tr.TimeSheet.IsArchive && !tr.TimeSheet.IsCompleted && tr.TimeOut != null
                group tr.BonusHour by
                    new {
                            tr.TimeSheet.Student,
                            MonthYear = tr.CreationDate.Value.Month + "/" + tr.CreationDate.Value.Year
                        }
                into g
                select new {g.Key.Student.AssignedId, g.Key.MonthYear, TotalHour = g.Sum()};
