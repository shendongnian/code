    public class Trie
    {
        public Trie(IEnumerable<string> words)
        {
            Root = new Node { Letter = '\0' };
            foreach (string word in words)
            {
                this.Insert(word);
            }
        }
    
        public bool MatchesPrefix(string sentence)
        {
            if (sentence == null)
            {
                return false;
            }
    
            Node current = Root;
            foreach (char letter in sentence)
            {
                if (current.Links.ContainsKey(letter))
                {
                    current = current.Links[letter];
                    if (current.IsWord)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
    
            return false;
        }
    
        private void Insert(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException();
            }
    
            Node current = Root;
            foreach (char letter in word)
            {
                if (current.Links.ContainsKey(letter))
                {
                    current = current.Links[letter];
                }
                else
                {
                    Node newNode = new Node { Letter = letter };
                    current.Links.Add(letter, newNode);
                    current = newNode;
                }
            }
    
            current.IsWord = true;
        }
    
        private class Node
        {
            public char Letter;
            public SortedList<char, Node> Links = new SortedList<char, Node>();
            public bool IsWord;
        }
    
        private Node Root;
    }
