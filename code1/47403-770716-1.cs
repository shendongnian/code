    public interface IHasID
    {
        int ID { get; set; }
    }
    DataContext [View Code]:
    namespace MusicRepo_DataContext
    {
        partial class Artist : IHasID
        {
            [Column(Name = "ArtistID", Expression = "ArtistID")]
            public int ID
            {
                get { return ArtistID; }
                set { throw new System.NotImplementedException(); }
            }
        }
    }
