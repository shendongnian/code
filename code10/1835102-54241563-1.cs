    public static List<DataObject> GuardarGrupos(string parametro){
        //List to return
        List<DataObject> returnList = new List<DataObject>();
        
        //Split the string on pipe to get each set of values
        var data = parametro.Split('|'); //No need to do a convert.char(), 
        //String.Split has an overload that takes a character, use single quotes for character
    
        //Iterate through each of the letters
        foreach (var check in data)
        {
           //Split on comma to get the individual values
           string[] values = check.Split(',');
           DataObject do = new DataObject()
           {
              X = values[0];
              Y = values[1];
           };
           returnList.Add(do);
        }
    
        return returnList;
    }
