private void SomeMethod()
{    
   List<Item> itemsList = GetItems();    
   foreach(Item i in itemsList)    
   {        
      MyClient client = new MyClient();      
      client.GetSomeValueCompleted += client_GetSomeValueCompleted;      
      <b>client.GetSomeValueAsync(i.ID, client);</b>
   } 
}   
private void client_GetSomeValueCompleted(object sender, GetSomeValueEventArgs e)
{  
   int id = e.Result;  
   
   //  how do I assign this ID to my itemsList object, i  ???
   <b>(e.UserState as MyClient).ID = id;</b>
}
