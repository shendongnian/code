     using OfficeOpenXml;
     using System.Collections.Generic;
     using System.IO;
    namespace equals
    {
        class Program
        {
            public static void Main()
            {
                try
                {
                    FileInfo newfile = new FileInfo(@"C:\Users\Evan\Desktop\new.xlsx");
                    ExcelPackage pkg = new ExcelPackage(newfile);
                    ExcelWorksheet wrksheet = pkg.Workbook.Worksheets[0];
                    var lastRow = wrksheet.Dimension.End.Row;
                    ExcelRange rng = wrksheet.Cells[1, 1, lastRow, 2];
                    System.Console.WriteLine(rng.Address);
                    List<int> valuesInRange = new List<int>();
                    int cellValue;
                    foreach (var cell in rng)
                    {
                        cellValue = System.Convert.ToInt32(cell.Value);
                        if (cellValue != 0)
                        {
                            valuesInRange.Add(cellValue);
                        }
                    }
                    int countOfList = valuesInRange.Count;
                    int[,] array = new int[countOfList/2, 2];
                    array = Populate2DArrayFromList(countOfList, valuesInRange);
                   foreach (var item in array)
                    {
                        System.Console.WriteLine(item);
                    }
                }
                catch (System.IO.IOException err)
                {
                    System.Console.WriteLine(err.Message);
                }
            }
 
            public static int[,] Populate2DArrayFromList(int countOfList, List<int> list)
            {
                int[,] array = new int[countOfList/2, 2];
                int listNum = 0;
                for(int rownum = 0; rownum < countOfList/2; rownum++)
                {
                    array[rownum, 0] = list[listNum];
                    System.Console.WriteLine("added to column A {0}", list[listNum]);
                    listNum = listNum + 2;
                }
                listNum = 1;
                for (int rownum = 0; rownum < countOfList/2; rownum++)
                {
                    array[rownum, 1] = list[listNum];
                    System.Console.WriteLine("added to column B {0}", list[listNum]);
                    listNum = listNum + 2;
                 }
                 return array;
            }
        }
    }
