LinkedListNode&lt;Day&gt; d1 = new LinkedListNode&lt;Day&gt;(new Day());
LinkedListNode&lt;Day&gt; d2 = new LinkedListNode&lt;Day&gt;(new Day());
LinkedList&lt;Day&gt; days = new LinkedList&lt;Day&gt;();
days.AddLast(d1); 
days.AddLast(d2);
// Now you can read the node directly
d1.Next...
// If you need to place it somewhere other than at the end (like say you want d2 before d1,
// but d1 is already in the list) use 'AddBefore' and 'AddAfter' eg:
days.AddLast(d2);
days.AddBefore(d2, d1);
