    using System.Text.RegularExpressions;
    :
    :
    do {
         fileRow = fileReader.ReadLine();
         if (!Regex.IsMatch(fileRow, @"^,*$")) 
         {
            fileRow = fileRow.Replace("\"", "");
            //       fileRow = fileRow.Replace("-", "");
            fileDataField = fileRow.Split(delimiter);
            fileDataField = fileRow.Split(',');
            gridLGTCash.Rows.Add(fileDataField);
          }
      }while (fileReader.Peek() != -1)
    fileReader.Close();
