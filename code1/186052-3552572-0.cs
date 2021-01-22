public class Taggable :ITaggable
    {
        private IDictionary&lt;string, object&gt; _tags = new Dictionary&lt;string, object&gt;();
        public void AddTag(string key, object tag)
        {
            _tags.Add(key,tag);
        }
        public T GetTag&lt;T&gt;(string key)
        {
            return (T) _tags[key];
        }
        public void RemoveTag(string key)
        {
            _tags.Remove(key);
        }
    }
