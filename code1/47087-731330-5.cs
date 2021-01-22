    class CounterClass
    {
       private int count;
       private Queue<int> deletions;
    
       public CounterClass()
       {
          count = 0;
          deletions = new Queue<int>();
       }
    
       public string GetNumber()
       {
          if (deletions.Count > 0)
          {
              return deletions.Dequeue().ToString();
          }
          return count++.ToString();
       }
    
       public void Delete(int num)
       {
          deletions.Enqueue(num);
       }
    }
