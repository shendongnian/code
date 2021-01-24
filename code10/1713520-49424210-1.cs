        public void Push(String name, int age, int manummer, double grade)
        {
            Node newnode = new Node(name, age, manummer, grade);
            current = headstudent = newnode;
            count = 1;
        }
        public void PrintList()
        {
            if (headstudent == null)
            {
                Console.WriteLine("the list is empty");
                return;
            }
            Node ptr = headstudent;
            while (ptr != null)
            {
                Console.WriteLine(ptr.S.Name + " " + ptr.S.Age + " " + ptr.S.MatriculationNumber + " " + ptr.S.Grade);
                ptr = ptr.next;
            }
            Console.ReadLine();
            // remove these lines:
            //else
            //    Console.WriteLine("the list is empty");
            // You should not increment count here anyway!
            //count++;
        }
        public void AddAtEnd(String name, int age, int manummer, double grade)
        {
            Node newnode = new Node(name, age, manummer, grade);
            if (headstudent == null)
                headstudent = newnode;
            else
            {
                current = headstudent;
                while (current != null)
                {
                    previous = current;
                    current = current.next;
                }
                previous.next = newnode;        // try current =
            }
            count++;
        }
        public void AddAtStart(String name, int age, int manummer, double grade)
        {
            Node newnode = new Node(name, age, manummer, grade);
            if (headstudent == null)
                current = headstudent = newnode;
            else
            {
                current = newnode;
                current.next = headstudent;
                headstudent = newnode;
            }
            count++;
        }
        public void RemoveFirst()
        {
            if (count > 0)
            {
                headstudent = headstudent.next;
                count--;
            }
            else
            {
                Console.WriteLine("list is empty");
            }
        }
        public void Replace(int manummer, int newNumber)
        {
            current = headstudent;
            while (current != null)
            {
                if (current.S.MatriculationNumber == manummer)
                {
                    current.S.MatriculationNumber = newNumber;
                    Console.WriteLine(manummer + " is replaced by: " + newNumber);
                    break;
                }
                current = current.next;
            }
        }
