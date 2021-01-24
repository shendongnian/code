    public class Example
    {
         public static void EnumEntities( IEnumerable entities )
         {
            foreach( var entity in entities )
            {
                Console.WriteLn( entity.ToString());
            }
         }
    }
