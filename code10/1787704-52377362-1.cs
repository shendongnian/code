    var maxUpdatedDatePerStudentList = Uow.ActivityTrackingUnitValues
                        .Where(atuv => atuv.Last_Updated_On != null
                                    && atuv.TBH_Activity_Tracking_Unit
                                           .StudentBehaviour
                                           .Student
                                           .TeamMembers
                                           .Any(tm => tm.Id == userId))
                        .Select(atuv => new 
                        { 
                            LastUpdatedDate = (DateTime)DbFunctions.TruncateTime(atuv.Last_Updated_On)),
                            StudentId = atuv.TBH_Activity_Tracking_Unit.StudentBehaviour.Student.Id
                        })
                        .GroupBy(sd => sd.StudentId)
                        .Select(sd => new { StudentId = sd.Key, MaxDate = sd.Max(d => d.LastUpdatedDate) })
                        .ToList();
