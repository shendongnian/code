        public void PrintList()
        {
            if (headstudent == null)
            {
                Console.WriteLine("the list is empty");
                return;
            }
            Node ptr = headstudent;
            while (ptr.next != null)
            {
                Console.WriteLine(ptr.S.Name + ptr.S.Age + ptr.S.MatriculationNumber + ptr.S.Grade);
                ptr = ptr.next;
            }
            Console.ReadLine();
            // remove these lines:
            //else
            //    Console.WriteLine("the list is empty");
            // You should not increment count here anyway!
            //count++;
        }
