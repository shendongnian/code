    public class Ville
    {
        public string wilPop { get; set; }
        public int identifiant { get; set; }
        public bool affectedD { get; set; }
        public Ville(string ewilPop, int eidentifiant, bool eaffectedD)
        {
            this.wilPop = ewilPop;
            this.identifiant = eidentifiant;
            this.affectedD = eaffectedD;
        }
    }
