    public class RandomBytes : IEnumerable<byte>, IEnumerable
    {
        public IEnumerator<byte> GetEnumerator()
        {
            //used null, but could also drop the nullable and just pass ulong.MaxValue into the method
            return GetEnumerator(null);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        //extracted the "main" method to a seperate method that takes a count
        protected IEnumerator<byte> GetEnumerator(ulong? count)
        {
            //use ulong.MaxValue when null gets passed, 
            //what ever you are doing with this code 18,446,744,073,709,551,615 iterations should be enough
            var c = count ?? ulong.MaxValue; 
            var rnd = new Random();
            for (ulong i = 0; i < c; i++)
                yield return (byte)rnd.Next(0, 255);
        }
    }
    public class RandomNBytes : RandomBytes
    {
        readonly ulong Count;
        public RandomNBytes(ulong count)
        {
            Count = count;
        }
        public new IEnumerator<byte> GetEnumerator()
        {
            return GetEnumerator(Count); //call the protected method
        }
    }
