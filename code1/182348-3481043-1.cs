    ObservableCollection<myClass> collection = new ObservableCollection<myClass>();
    public void qc_GetOfficerNamesCompleted(object sender, GetOfficerNamesCompletedEventArgs e)   
    {   
     // Now try adding this code  
    for(int i=0; i<e.Result.Count;i++)  
    {  
         // I do this because, I don't want the Client class to be unaware of the class myClass
         collection.Add(new myClass()
               {
                 str1 = e.Result[i].str1,
                 str2 = e.Result[i].str2,
                 str3 = e.Result[i].str3,
                 int1 = e.Result[i].int1       
              });
    }   
    for(int i=0; i<collection.Count;i++)
    {
       Items.Add(collection[i].str1); // Add the string you want. I ve used str1 here.
    }
    }
