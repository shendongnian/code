    public abstract class Document<T> where T : Section
 
    public abstract class Section
    public class Book : Document<Chapter>
    public class Chapter : Section
