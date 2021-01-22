    /// <summary>
    /// Allows a tag of any type to be used to get a result of type TResult
    /// </summary>
    /// <typeparam name="TResult">The result type after using the tag</typeparam>
    public interface ITagUser<TResult>
    {
        TResult Use<T>(ITag<T> tag);
    }
    /// <summary>
    /// Allows a tag of any type to be used (with no return value)
    /// </summary>
    public interface ITagUser
    {
        void Use<T>(ITag<T> tag);
    }
    
    /// <summary>
    /// Wraps a tag of some unknown type.  Allows tag users (either with or without return values) to use the wrapped list.
    /// </summary>
    public interface IExistsTag
    {
        TResult Apply<TResult>(ITagUser<TResult> user);
        void Apply(ITagUser user);
    }
    /// <summary>
    /// Wraps a tag of type T, hiding the type itself.
    /// </summary>
    /// <typeparam name="T">The type of element contained in the tag</typeparam>
    class ExistsTag<T> : IExistsTag
    {
        ITag<T> tag;
        public ExistsTag(ITag<T> tag)
        {
            this.tag = tag;
        }
        #region IExistsTag Members
        public TResult Apply<TResult>(ITagUser<TResult> user)
        {
            return user.Use(tag);
        }
        public void Apply(ITagUser user)
        {
            user.Use(tag);
        }
        #endregion
    }
    public interface ITag
    {
        string TagName { get; }
        Type Type { get; }
    }
    public interface ITag<T> : ITag
    {
        T InMemValue { get; set; }
        T OnDiscValue { get; set; }
    }
    public class Tag<T> : ITag<T>
    {
        public Tag(string tagName)
        {
            TagName = tagName;
        }
        public string TagName { get; private set; }
        public T InMemValue { get; set; }
        public T OnDiscValue { get; set; }
        public Type Type { get { return typeof(T); } }
    }
    public class TagSetter : ITagUser
    {
        #region ITagUser Members
        public void Use<T>(ITag<T> tag)
        {
            tag.InMemValue = tag.OnDiscValue;
        }
        #endregion
    }
    public class TagExtractor : ITagUser<ITag>
    {
        #region ITagUser<ITag> Members
        public ITag Use<T>(ITag<T> tag)
        {
            return tag;
        }
        #endregion
    }
    public class MusicTrack
    {
        public MusicTrack()
        {
            TrackTitle = new Tag<string>("TrackTitle");
            TrackNumber = new Tag<int>("TrackNumber");
            Tags = new Dictionary<string, IExistsTag>();
            Tags.Add(TrackTitle.TagName, new ExistsTag<string>(TrackTitle));
            Tags.Add(TrackNumber.TagName, new ExistsTag<int>(TrackNumber));
        }
        public IDictionary<string, IExistsTag> Tags;
        public ITag<string> TrackTitle { get; set; }
        public ITag<int> TrackNumber { get; set; }
    }
    public static class Main
    {
        public static void DoSomething_WorksButNotIdeal()
        {
            MusicTrack track1 = new MusicTrack();
            MusicTrack track2 = new MusicTrack();
            TagSetter setter = new TagSetter();
            TagExtractor extractor = new TagExtractor();
            // Set some values on the tracks
            foreach (IExistsTag tag in track1.Tags.Values)
            {
                tag.Apply(setter);
                // do stuff using base interface if necessary
                ITag itag = tag.Apply(extractor);
            }
        }
    }
