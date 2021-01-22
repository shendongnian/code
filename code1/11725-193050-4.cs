      static string appendFolders(params StringOrArray[] folders)
         { return folders.SelectMany(x=>x.AsEnumerable())
                         .Aggregate("",
                           (output, f)=>Path.Combine(output,f.TrimStart('\\')));
         }
         
       class StringOrArray
         { string[] array;
           public IEnumerable<string> AsEnumerable()
            { return soa.array;}
           public static implicit operator StringOrArray(string   s)   
            { return new StringOrArray{array=new[]{s}};}
           
           public static implicit operator StringOrArray(string[] s)  
            { return new StringOrArray{array=s};}
         }
         
