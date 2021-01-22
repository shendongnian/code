    <DnaLibrary Language="C#">
       using System;
       using ExcelDna.Integration;
       
       public class MyFunctions
       {
          [ExcelFunction(Description="Calculate Stuff", Category="Cool Functions")]
          public static double HeronicCal(int a, int b, int c)
          {
             //first compute S = (a+b+c)/2
             double S = (a + b + c) / 2;
             double area = Math.Sqrt(S * (S - a) * (S - b) * (S - c));
             return area;        
          }
       }
    </DnaLibrary>
