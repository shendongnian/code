    public class MyList<T> : IEnumerable<T>{
    
        public MyList(IEnumerable<T> source){
            data.AddRange(source);
        }
    
        public IEnumerator<T> GetEnumerator(){
            return data.Enumerator();
        }
    
        private List<T> data = new List<T>();
    }
