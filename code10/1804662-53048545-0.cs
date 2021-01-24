    class SerializationHelper
    {
       public void Serialize<W,T>(W data,Func<int,T> x) where W : IEnumerable
       {
            //do something with data using Func
            foreach(int i in data)
            {
                Console.WriteLine(x(i));
            }
       }
    }
    
    Func<int,int> x = (i) => {return i*i; };  // Takes one integer as input and returns square of it
    
    new SerializationHelper().Serialize<int[],int>(new int[] { 1, 2, 3 }, x);
