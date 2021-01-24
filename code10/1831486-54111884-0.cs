    var grouppedData=from i in context.Students
                     let mykey = getGroupedKey(i)
                     group by mykey int g
                     select new
                     {
                       PrimaryStudentCount = g.Sum(k => k.PrimaryStudent),
                       SecondaryStudentCount = g.Sum(k => k.SecondaryStudent)
                     }
    private string getGroupedKey(Data i)
    {
         if (...)
         {
             return string.format(...}
         }
         ....
    }
