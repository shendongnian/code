    class ClassName
    {
        public bool Equals(ClassName other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                //Do your equality test here.
            }
        }
        public override bool Equals(object obj)
        {
            ClassName other = obj as null; //Null and non-ClassName objects will both become null
            if (obj == null)
            {
                return false;
            }
            else
            {
                return Equals(other);
            }
        }
        public bool operator ==(ClassName left, ClassName right)
        {
            if (left == null)
            {
                return right == null;
            }
            else
            {
                return left.Equals(right);
            }
        }
        public bool operator !=(ClassName left, ClassName right)
        {
            if (left == null)
            {
                return right != null;
            }
            else
            {
                return !left.Equals(right);
            }
        }
        public override int GetHashCode()
        {
            //Return something useful here, typically all members shifted or XORed together works
        }
    }
