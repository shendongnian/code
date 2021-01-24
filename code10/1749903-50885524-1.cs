        var sampleExcel = new ExcelQueryFactory(@"I:\Book1.xlsx");
        var sampleWorksheet = from workSheet in sampleExcel.Worksheet("Sheet1") select workSheet;
        var selectedValues = from excelRow in sampleExcel.Worksheet()
           select new { name = excelRow[0], number =Convert.ToInt32(excelRow[1]) };
            foreach (var item in selectedValues)
            {
                Console.WriteLine(string.Format("Name is {0} ,number is {1}",item.name,item.number));
            }
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (var item in selectedValues)
            {
                dict.Add(item.number, item.name);
                Console.WriteLine(string.Format("Name is {0} ,number is {1}", item.name, item.number));
            }
