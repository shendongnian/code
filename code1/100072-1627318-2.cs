    public interface IReadable <T>
    {
        T Read(string ID);
    }
    public class NoteAdapter : IReadable<Note>
    {
        public Note Read<Note>(string ID) {
            return new Note();
        }
    }
