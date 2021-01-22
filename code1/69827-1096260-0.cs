    public class ActingAsArray {
       private int[] _arr;
       public ActingAsArray(int[] arr) { _arr = arr; }
       public int this[int v] { get { return _arr[v]; } }
    }
    public ActingAsArray pal { get { return new ActingAsArray(realArray); } }
