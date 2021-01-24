    var answer = (from p in context.Patients
                  join v in context.PatientVisits on p.ID equals v.PatientID into subs
                  from sub in subs.DefaultIfEmpty()
                  group sub by new { p.ID, p.FirstName, p.LastName } into gr
                  select new 
                  {
                      gr.Key.FirstName,
                      gr.Key.LastName,
                      VisitDate = gr.Max(x => x == null ? null : x.VisitDate)
                  }).ToList();
