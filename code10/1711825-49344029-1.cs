            var listA = new List<int> { 1, 3, 5 };
            var listB = new List<int> { 1, 4, 3 };
  
            //Removes items in B that aren't in A.
            //This will remove 4, leaving the sequence of B as 1,3
            listB.RemoveAll(x => !listA.Contains(x));
            //Gets items in A that aren't in B
            //This will return the number 5
            var items = listA.Where(y => !listB.Any(x => x == y));
            //Add the items in A that aren't in B to the end of the list
            //This adds 5 to the end of the list
            foreach(var item in items)
            {
                listB.Add(item);
            }
            //List B should be 1,3,5
            Console.WriteLine(listB);
