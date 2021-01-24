     Dictionary<int, Dictionary<String, String>> values = new Dictionary<int, Dictionary<String,String>>();
     using(FileStream fileStream = new FileStream(@"D:\MyCSV.csv", FileMode.Open, FileAccess.Read, FileShare.Read)) {
         using(StreamReader streamReader = new StreamReader(fileStream)){
              //You can skip this line if there is no header
              // Then instead of Dictionary<String,String> you use List<String>
              var headers = streamReader.ReadLine().Split(',');
              String line = null;
              int lineNumber = 1;
              while(!streamReader.EndOfStream){
                   line = streamReader.ReadLine().split(',');
                   if(line.Length == headers.Length){
                       var temp = new Dictionary<String, String>();
                       for(int i = 0; i < headers.Length; i++){
                          // You can remove '"' character by line[i].Replace("\"", "") or through using the Substring method
                          temp.Add(headers[i], line[i]);
                       }
                       values.Add(lineNumber, temp);
                   }
                   lineNumber++;
              }              
         }
