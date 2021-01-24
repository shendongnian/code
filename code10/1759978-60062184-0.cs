    public class MyTable
        {
            [Key]
            public virtual int id { get; set; }
            // A column which contains any text
            [StringLength(255, MinimumLength = 0)]
            public virtual string string my_text_column { get; set; }
        }
    }
