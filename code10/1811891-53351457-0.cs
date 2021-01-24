    abstract class Item : Monobehaviour {
        public abstract void AddToGameObject (GameObject obj);
    }
    class Weapon : Item {
        int damage;
        int cooldown;
        public override void AddToGameObject (GameObject obj) {
            var copy      = obj.AddComponent <Weapon> ();
            copy.damage   = damage;
            copy.cooldown = cooldown;
        }
    }
    class Armor : Item {
        int protection;
        public override void AddToGameObject (GameObject obj) {
            var copy        = obj.AddComponent <Armor> ();
            copy.protection = protection;
        }
    }
