        var cardatas = _fileParser.Parse<CarFileParserList, List<CarData>>("car.txt");
        class CarFileParser
        {
         public List<CarFile> CarFileParserList{get;set;}
        }
        public class CarFile
        {
         //create property here
        }
