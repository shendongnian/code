    [Table("test")]
    public class Test : IDbTable
    {
        [Key]
        public int TestId { get; set; }
        public string Name { get; set; }
    }
.......
    Test t = new Test { Name = textBox2.Text };
    textBox1.Text = t.Insert().ToString();
