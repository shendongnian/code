            LinkedList<Temp> list = new LinkedList<Temp>(); 
 
            for (var i = 0; i < 123456; i++)
            {
                var a = new Temp(i, i, i, i);
                list.AddLast(a);
                var curNode = list.First;
                for (var k = 0; k < i/2; k++) // in order to insert a node at the middle of the list we need to find it
                    curNode = curNode.Next;
                list.AddAfter(curNode, a); // insert it after
            }
            decimal sum = 0;
            foreach (var item in list)
                sum += item.A;
