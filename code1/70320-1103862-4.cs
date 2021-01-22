    public class Boss
    {
       private string name;
       private List<Hashtable> dogs;
       private int limit;
    
       public Boss(string name, int dogLimit)
       {
          this.name = name;
          this.dogs = new List<Hashtable>();
          this.limit = dogLimit; 
       }
       public string Name { get { return this.name; } }
       public void AddDog(string nickname, Dog dog)
       {
          if (!this.dogs.Contains(nickname) && !this.dogs.Count == limit)
          {
             this.dogs.Add(nickname, dog);
             dog.AddBoss(this);
          } 
       }
       public void RemoveDog(string nickname)
       {
           this.dogs.Remove(nickname);
           dog.RemoveBoss(this);
       }
       public void Hashtable Dogs { get { return this.dogs; } }
    }
    public class Dog
    {
       private string name;
       private List<Boss> bosses;
       public Dog(string name)
       {
          this.name = name;
          this.bosses = new List<Boss>();
       }
       public string Name { get { return this.name; } }
       public void AddBoss(Boss boss)
       {
          if (!this.bosses.Contains(boss))
          {
              this.bosses.Add(boss);
          }
       }
       public void RemoveBoss(Boss boss)
       {
          this.bosses.Remove(boss);
       }  
       public ReadOnlyCollection<Boss> Bosses { get { return new ReadOnlyCollection<Boss>(this.bosses); } }
    }
