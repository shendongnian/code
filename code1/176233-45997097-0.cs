      class Program
         {
              //Declare Enum
              enum colors {white=0,black=1,skyblue=2,blue=3 }
          static void Main(string[] args)
            {
              // It will return single color name which is "skyblue"
                 string colorName=Enum.GetName(typeof(colors),2);
    
              //it will returns all the color names in string array.
              //We can retrive either through loop or pass index in array.
                 string[] colorsName = Enum.GetNames(typeof(colors));
        
             //Passing index in array and it would return skyblue color name
                 string colName = colorsName[2];
        
                 Console.WriteLine(colorName);
                 Console.WriteLine(colName);
                 Console.ReadLine();
            }
        }
