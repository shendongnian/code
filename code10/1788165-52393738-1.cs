    public class DocumentGenerationParticipantsResponse
    {
        public List<DocumentGenerationParticipantResponse> Participants { get; }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is List<DocumentGenerationParticipantResponse> list))
            {
                return false;
            }
            if (list.Count != this.Participants.Count)
            {
                return false;
            }
            return this.Participants.SequenceEqual(list);
        }
        // Remainder snipped
