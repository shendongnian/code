       [Table("Bs")]
        class B
        {
    public A referredA {get;set;}
            public B(A a) 
            {
               referredA=a;
            }
        }
