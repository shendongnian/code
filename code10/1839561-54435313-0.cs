            IEnumerable< NEWStudentAllocationDTO> grouped = l.GroupBy(x => new { x.AssessmentId, x.Username, x.WorkSupervisor })
                .Select(x => new NEWStudentAllocationDTO()
                {
                    AssessmentId = x.Key.AssessmentId,
                    WorkSupervisor = x.Key.WorkSupervisor,
                    Username = x.Key.Username,
                    SITSupervisor = x.Select(y => y.SITSupervisor).ToList()
                });
