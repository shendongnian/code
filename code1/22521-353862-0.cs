     public static void AppendCollection( this StringBuilder builder,
                                          ICollection collection )
     {
         foreach (var item in collection)
         {
            builder.AppendLine( Convert.ToString( item ) );
         }
     }
