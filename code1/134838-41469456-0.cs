    public class Shift : MonoBehaviour {
         //Initialize Array
         public int[] queue;
    
         void Start () {
              //Create Array Rows
              queue = new int[5];
    
              //Set Values to 1,2,3,4,5
              for (int i=0; i<5;i++)
              {
                   queue[i] = i + 1;
              }
    
              //Get the integer at the first index
              int prev = queue[0];
    
              //Copy the array to the new array.
              System.Array.Copy(queue, 1, queue, 0, queue.Length - 1);
    
              //Set the last shifted value to the previously first value.
              queue[queue.Length - 1] = prev;
