    public class Location : MonoBehaviour
    {
       public int howmany;// how many lines are in the text file
    
      void Start()
        {
           List<string> fileLines = new List<string>(System.IO.File.ReadAllLines(Application.persistentDataPath + "\\" + "locationdatabase.txt"));
            howmany  = (fileLines.Count);
            Debug.Log(fileLines[4520]);// look at a particular line in the file
            Debug.Log(howmany);
    }
}
