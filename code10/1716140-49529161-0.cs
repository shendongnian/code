    public class Key:IEquatable<Key> {
        public string nameA;
        public string nameB;
    
        public bool Equals(Key other)
        {
            if(other == null)
                return false;
            if(ReferenceEquals(this,other))
                return true;
            return (string.Equals(this.nameA,other.nameA) && string.Equals(this.nameB,other.nameB))
                    || (string.Equals(this.nameA,other.nameB) && string.Equals(this.nameB,other.nameA));
        }
        public override bool Equals(object obj){
            if(obj == null)
                return false;
            if(ReferenceEquals(obj,this))
                return true;
            return Equals((Key)obj);
        }
        public override int GetHashCode(){
            return (nameA?.GetHashCode() ^ nameB?.GetHashCode()) ?? 0;
        }
     }
