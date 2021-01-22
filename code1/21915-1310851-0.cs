    public static void main(string[] args)
    {
    List names = new List();
    
    names.Add(“Saurabh”);
    names.Add("Garima");
    names.Add(“Vivek”);
    names.Add(“Sandeep”);
    
    string stringResult = names.Find( name => name.Equals(“Garima”));
    }
