    public class EnglishAlphabetProvider : IAlphabetProvider
    {
        public IEnumerable<char> GetAlphabet()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                yield return c;
            } 
        }
    }
    IAlphabetProvider provider = new EnglishAlphabetProvider();
    foreach (char c in provider.GetAlphabet())
    {
        //do something with letter 
    } 
