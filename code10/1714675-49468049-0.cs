    class Test
    {
         public string Name { set; get; }
         public string Address { set; get; }
    
         public override string ToString(){
             return $"name: {Name}, address: {Address}";
         }
    }
