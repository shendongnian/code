     SoupToNuts record; //class with same columns found in csv file
     List<SoupToNuts> SoupToNutsList = new List<SoupToNuts>(); 
          
     while (csv.Read())
     {
          if (!csv.IsRecordEmpty())
          {
              record = csv.GetRecord<SoupToNuts>();
              SoupToNutsList.Add(record);
          }
     }
