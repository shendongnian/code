    public interface IReadable <T>
    {
        T Read(string ID);
    }
    public class NoteAdapter : IReadable<Note>
    {
        public Note Read(string ID) {
            return new Note();
        }
    }
