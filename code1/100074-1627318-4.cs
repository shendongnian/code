    public class NoteAdapter : IReadable<Note> /* IReadable defines T to be Note */
    {
        public Note Read<Note>(string ID) { /* Here, you're declaring a generic parameter */
                                            /* named Note.  This name then conflicts with */
                                            /* the existing type name Note */
            return new Note();
        }
    }
