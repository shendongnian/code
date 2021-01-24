    class CFileRow : public CObject
       {
    //8 fields
    public:
        CFileRow(const string line)
          {
          //convert string line that you are to read from file into class
          }
        ~CFileRow(){}
       };
    CArrayObj* fileRowArray = new CArrayObj();
    
    while(!FileIsEnding(FileReader))
      {
         string line=FileReadString(FileReader);
         fileRowArray.Add(new CFileRow(line));
      }
