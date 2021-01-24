        public class Feature
        {
           
            public int Id { get; set; }
            public string ColumnValues { get; set; }
        }
    
      var features = new List<Feature> { new Feature {Id=1,ColumnValues="carrot" } ,
                     new Feature {Id=1,ColumnValues="dirt" },
                      new Feature {Id=1,ColumnValues="banana" }, new Feature {Id=1,ColumnValues="apple" }
                };
    
                var query = (from feature in features
                             where String.Compare(feature.ColumnValues, "c", StringComparison.OrdinalIgnoreCase) < 0
                             select feature).OrderBy(x => x.ColumnValues);
