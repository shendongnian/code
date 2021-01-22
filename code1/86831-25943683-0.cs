    [DataContract]
    [KnownType(typeof(NoteEntitySegment)]
    [KnownType(typeof(NoteTextSegment)]
    public class TokenizedNote
    {
        [DataMember] public Note Note { get; set; }
        [DataMember] public List<NoteSegment> NoteSegments { get; set; }
    }
