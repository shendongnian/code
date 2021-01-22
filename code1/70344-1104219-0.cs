    var members = typeof(TestMe).GetFields().Select(m => m.FieldType );
    
                foreach (var item in members)
                    Console.WriteLine(item);
    
                
    
    
           public class TestMe
            {
                public string A;
                public int B;
                public byte C;
                public decimal D;
            }
