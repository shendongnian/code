     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Text;
     using System.Threading.Tasks;
     using System.Text.RegularExpressions;
     namespace testApp
     {
         class Program
         {
             static void Main(string[] args)
             {
                 string tempString = "morenonxmldata<tag1>0002</tag1>morenonxmldata";
                 tempString = Regex.Replace(tempString, "[\\s\\S]*<tag1>", "");//removes all leading data
                 tempString = Regex.Replace(tempString, "</tag1>[\\s\\S]*", "");//removes all trailing data
           
                 Console.WriteLine(tempString);
                 Console.ReadLine();
             }
         }
     }
