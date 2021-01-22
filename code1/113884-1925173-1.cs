    // first some implementations
    public class Sword : ISword {
        public void Kill() { // imp }
        public void Slice() { // imp }
    }
    public class Shuriken : IShuriken {
        public void Kill() { // imp }
        public void Pierce() { // imp }
    }
    // and I would change the Ninja class to
    public class Ninja {
        public ISword Sword { get; private set; }
        public IShuriken Shuriken { get; private set; }
  
        public Ninja(ISword sword, IShuriken shuriken) {
            this.Sword = sword;
            this.Shuriken = shuriken;
        }
        public void BrutalKill() {
            Shuriken.Pierce();
            Shuriken.Pierce();
            Shuriken.Pierce();
           
            // either weapon can kill
            // so lets close the distance and use the sword
            Sword.Kill();
        }
        
        public void HonorKill {
            Sword.Slice();
        }
    }
    // creating the class
    // where Ioc.Resolve is specific to the container implementation
    var ninja = new Ninja(IoC.Resolve<ISword>(), IoC.Resolve<IShuriken>());
