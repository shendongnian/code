    //Assumes setA and setB are unique internally
       public DataRow[] GetUnionRows(DataRow[] setA, DataRow[] setB){
          List<DataRow> resultList = new List<DataRow>(setA);
          foreach (DataRow row in setB){
              if (!Contains(setA, row)){
                 resultList.add(row);
              }
          }
          return resultList.toArray();
       }
    
       private bool YourEquals(DataRow a, DataRow b){
          //Whatever
       }
    
       private bool Contains(DataRow[] setA, DataRow b){
          foreach(DataRow a in setA){
             if (YourEquals(a,b)){
                return true;
             }  
          }
          return false;
       }
