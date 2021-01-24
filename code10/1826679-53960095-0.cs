    class Program
    {
        static void Main(string[] args)
        {
             // Simple Array:
             string[] array = new string[] { "1" , "2" , "3" , "4" , "5" , " "};
                
             // Converting Array into a List. (Because we don't have any remove method for array.)
             var arrayList = array.ToList();
    
             // Retrieving last element.
             string _lastSpace = arrayList.Last();
    
             // Confirmation: Last Element is space or not.
             if(_lastSpace == " ")
                 arrayList.RemoveAt(arrayList.LastIndexOf(" "));
                
             // Converting the list without having last Element with space to "array"
             array = arrayList.ToArray();
    
        }
    }
