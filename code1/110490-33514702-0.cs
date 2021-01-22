    public class Example
    {
        public void hashTableMethod()
        {
            Hashtable ht = new Hashtable();
            ht.Add(5002894, "Hemant Kumar");
            ht.Add(5002895, "Himanshee Ratnakar");
            ht.Add(5002896, "Pooja Bhatnagar");
            ht.Add(5002897, "Hina Saxena");
            ht.Add(5002898, "Kanika Aneja");
            ht.Add(5002899, "Hitesh Chaudhary");
            Console.Write("\nNumber of Key-Value pair elements in HashTable are : {0}",ht.Count);
            Console.WriteLine("Elements in HashTable are: ");
            ICollection htkey = ht.Keys;
            foreach (int key in htkey)
            {
                Console.WriteLine("{0}. {1}",key,ht[key]);
            }
            string ch="n";
            do
            {
                Console.Write("\n\nEnter the name to check if it is exist or not, if not then it will add: ");
                string newName=Console.ReadLine();
                if(ht.ContainsValue(newName))
                {
                    Console.Write("\nYour Name already Exist in the list!!");
                }
                else
                {
                    Console.Write("\nSorry that name doesn't exist but it will be added!!");
                    int getKey = 0;
                    
                    int[] htk= new int[ht.Count];
                    ht.Keys.CopyTo(htk,0);
                    
                    string[] val=new string[ht.Count];
                    ht.Values.CopyTo(val,0);
                    
                    Array.Sort(htk,val);
                    foreach (int id in htk)
                    {
                        getKey = id;  
                    }
                    ht.Add(getKey+1,newName);
                }
                Console.Write("\nDo you want to search more??(y/n) :");
                ch=Console.ReadLine();
            }while(ch=="y"||ch=="Y");
            Console.Write("\nNew List Items: \n");
            ICollection htkeys = ht.Keys;
            foreach (int key in htkeys)
            {
                Console.WriteLine("{0}. {1}",key,ht[key]);
            }
        }
    }
