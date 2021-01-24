    List<TeacherSubjectVM> query = (from t in uow.staffs
                                    join ts in uow.teachersubjects on t.ID equals ts.teacherID
                                    join s in uow.subjects on ts.subjectID equals s.ID
                                    select new TeacherSubjectVM
                                    {
                                        Id = ts.subjectID,
                                        subjectName = s.Name,
                                        teacherName = t.fname,
                                    }).ToList();
    List<TeacherSubjectVM> query1 = (from t in uow.subjects
                                     join ts in uow.classsubjects on t.ID equals ts.subjectID
                                     join s in uow.jamats on ts.subjectID equals s.ID
                                     select new TeacherSubjectVM
                                     {
                                         Id = ts.subjectID,
                                         section = s.section,
                                         className = s.name,
                                     }).ToList();
    query.ForEach(item => {
        var otherItem = query1.Where(itm => itm.Id == item.Id).FirstOrDefault();
        
        item.subjectName = otherItem?.subjectName;
        item.teacherName = otherItem?.teacherName;
    });
