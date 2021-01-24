    [Table("Media")]
    public class Media
    {
        [Key]
        public long Id { get; set; }
           
        [NotUpdateable]
        public int OwnerId { get; set; }
        public string Name { get; set; }
    }
    [Test]
    public void DapperContribNotWriteableField()
    {
        // Arrange
        var conn = new SqlConnection(
            "Data Source=vrpisilstage.c0hnd1p1buwt.us-east-1.rds.amazonaws.com;Initial Catalog=VRPISIL;User ID=VRPISILSTAGE;Password=ottubansIvCajlokojOt;Connect Timeout=100");
        conn.Open();
        var media = new Media
        {
            OwnerId = 100500,
            Name = "Media"
        };
        // Act
        media.Id = conn.Insert(media);
        media.OwnerId = 500100;
        conn.MyUpdate(media);
        var result = conn.Get<Media>(media.Id);
        // Assert
        Assert.AreEqual(result.OwnerId, 100500);
    }
