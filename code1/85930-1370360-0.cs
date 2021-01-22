Console.BufferHeight = Int16.MaxValue - 1; // ***** Alters the BufferHeight *****
List&lt;string&gt; myList = new List&lt;string&gt;();
for (int x = 0; x &lt; 100000; x++) 
    myList.Add(x.ToString()); 
foreach (string s in myList) { 
    Console.WriteLine(s); 
}
