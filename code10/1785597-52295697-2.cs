    public class Importer
    ...
    IList<NewDataObj> n_obj = new List<NewDataObj>();    
    foreach (var item in data.AsEnumerable().Where(o => o.Field<string>("MyID") == ImportID)){             
    
             n_obj.Add(new NewDataObj(item, ID, ref currow));//one change
             currow++;}
    ....
