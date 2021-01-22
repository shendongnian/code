           var myarray = "test1, 1, anotherstring, 5, yetanother, 400";
           System.Collections.IEnumerator iEN = myarray.Split(',').GetEnumerator();
           var strList = new List<string>();
           while (iEN.MoveNext())
           {
               var first = iEN.Current;
               iEN.MoveNext();
               strList.Add((string)first + "," + (string)iEN.Current);
           }
:)
