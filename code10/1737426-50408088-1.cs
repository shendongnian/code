    public class ExampleClass : MonoBehaviour
    {
        public string url = "http://itunes.apple.com/lookup?id=1218822890";
        IEnumerator Start()
        {
            using (WWW www = new WWW(url))
            {
                yield return www;
                string textRead = www.text;
    			// ...
            }
        }
    }
