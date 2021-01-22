      static string appendFolders(params StringOrArray[] folders)
         { return folders.SelectMany(x=>(string[]) x)
                         .Aggregate("",
                           (output, f)=>Path.Combine(output,f.TrimStart('\\')));
         }
         
       class StringOrArray
         { string[] array;
           public static implicit operator StringOrArray(string   s)   
           { return new StringOrArray{array=new[]{s}};}
           
           public static implicit operator StringOrArray(string[] s)  
           { return new StringOrArray{array=s};}
           public static explicit operator string[](StringOrArray soa) 
           { return soa.array;}
         }
         
