    class TransposedDetailObject {
      public String Column1 { get; set; }
      public String Column2 { get; set; }
      public String Column3 { get; set; }
    }
    var transposedList new List<TransposedDetailObject> {
      new TransposedDetailObject {
        Column1 = someList[0].Titel,
        Column2 = someList[2].Titel,
        Column3 = someList[3].Titel
      },
      new TransposedDetailObject {
        Column1 = someList[0].Value1,
        Column2 = someList[2].Value1,
        Column3 = someList[3].Value1
      },
      ...
    };
