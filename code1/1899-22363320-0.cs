    public class MyHash : IEquatable<MyHash>
    {        
        public byte[] Val { get; private set; }
        public MyHash(byte[] val)
        {
            Val = val;
        }
       
        /// <summary>
        /// Test if this Class is equal to another class
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(MyHash other)
        {
            if (other.Val.Length == this.Val.Length)
            {
                for (var i = 0; i < this.Val.Length; i++)
                {
                    if (other.Val[i] != this.Val[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }            
        }
              
        public override int GetHashCode()
        {            
            var str = Convert.ToBase64String(Val);
            return str.GetHashCode();          
        }
    }
