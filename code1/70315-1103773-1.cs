    public class Dog
    {
        public List<Boss> Bosses;
    
        public void AddBoss( Boss b )  
        {
            if( b != null && Bosses.Contains (b) == false )
            {
                Bosses.Add (b);
                b.AddDog (this);
            }
        }
    
        public void RemoveBoss( Boss b )
        {
             if( b !=null && Bosses.Contains (b) )
             {
                 Bosses.Remove (b);
                 b.RemoveDog (this);
             }
        }
    }
    
    public class Boss
    {
        public List<Dog> Dogs;
    
        public void AddDog( Dog d )
        {
             if( d != null && Dogs.Contains (d) == false )
             {
                  Dogs.Add(d);
                  d.AddBoss(this);
             }
        }
    
        public void RemoveDog( Dog d )
        {
            if( d != null && Dogs.Contains(d) )
            {
                Dogs.Remove (d);
                d.RemoveBoss(this);
            }
        }
    }
