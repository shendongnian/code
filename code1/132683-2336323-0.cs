    //I am using public fields for demonstration.  You will want to make them properties
    public class Bullet {
      public bool Active;
      public int thisPosition;
      public int PrevBullet = -1;
      public int NextBullet = -1;
      public List<Bullet> list;
      
      public void Activate(Bullet lastBullet) {
        this.Active = true;
        this.PrevBullet = lastBullet.thisPosition;
        list[this.PrevBullet].NextBullet = this.thisPosition;
      }
      public void Deactivate() {
        this.Active = false;
        list[PrevBullet].NextBullet = this.NextBullet;
        list[NextBullet].PrevBullet= this.PrevBullet;
      }
    }
