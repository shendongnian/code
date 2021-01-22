    var firstItem = new List<dynamic>() { 
        new { DocId = 0, Page = "All_Forms ", PageNumber = 0}
    };
    var pages = (from p1 in firstItem
                 select p1).Union(
                 from p2 in MedicalReports
                 where p2.PaperStyle == "Normal" &&
                        p2.PageNumber != 10000
                 orderby p2.DocId
                 select new
                 {
                     DocId = p2.DocId,
                     Page = ((p2.CustomPage != null) ? p2.CustomPage : p2.PageNumber.ToString()) + ". " + p2.Title,
                     PageNumber = p2.PageNumber
                 });
