    class User {
       //...
       public string NameAndAge
       {
          get
          {
             return string.Format("{0}, {1} {2}",LastName , FirstName , Age);
          };
       }
    }
    
    <Label Name="someLabel" Content="{Binding NameAndAge}")/>
