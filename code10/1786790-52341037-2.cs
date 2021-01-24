    // and also change the declarations in the main method to: new TranslationDataList 
    public class TranslationDataList : List<TranslationData>
    {
        public override int GetHashCode()
        {
            int hash = 13;
            // string.GetHashCode() is not reliable. This should be an algorithm that returns the same value for two different lists that contain the same data
            foreach (var data in this)
                hash = (hash * 7) + data.Text.GetHashCode(); 
            return hash;
        }
        public override bool Equals(object obj)
        {
            var other = obj as TranslationDataList;
            if (other == null) return false;
            if (other.Count != Count) return false;
            // write the equality logic here. I don't know if it's ok!
            for (int i = 0; i < other.Count; i++)
                if (other[i].Text != this[i].Text)
                    return false;
            return true;
        }
    }
