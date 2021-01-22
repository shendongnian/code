    public class TrackReference
    {
        private Guid _id;
        public Track Track
        {
            get { return MediaCache.Instance.GetTrack(id); }
        }
        public TrackReference(Track track)
        {
            _id = track.Id;
        }
        public TrackReference(Guid trackId)
        {
            _id = trackId;
        }
    }
