            System.Collections.IEnumerator le = ((long[])(b)).GetEnumerator();
            int i2;
            while (le.MoveNext())
            {
                i2 = (int)(long)le.Current;
                
            }
            
            
            Person[] p = new Person[1] { mypers };
                  
            System.Collections.IEnumerator e = ((Person[])(p)).GetEnumerator();
           
            Customer c;
               while (e.MoveNext())
               {
                   c = (Customer)(Person)e.Current;
          
                }
            
