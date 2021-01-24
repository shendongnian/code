    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         // in databases for this context, every OrderItem belongs to exactly one Order
         // using foreign key "order_id"
         // model the table with the OrderItems:
         var orderItemTableBuilder = modelBuilder.Entity<OrderItem>();
         // (1) if needed: give it a non-default table name
         // (2) if needed: tell which property is the primary key
         // (3) design the one-to-many:
         //     (3a) between which tables?
         //     (3b) which property holds the foreign key?
         orderItemTableBuilder
             .ToTable("MyTableName")                          // (1)
             .HasKey(orderItem => orderItem.ItemNo            // (2)
             // (3) design one to many
             .HasRequired(orderItem => orderItem.Order)       // (3a) 
             .WithMany(order => order.OrderItems)             // (3a)
             .HasForeignKey(orderItem => orderItem.orderId);  // (3b)
         // model property orderId: it must be stored in column "order_id"
         orderItemTableBuilder.Property(orderItem => orderItem.orderId)
              .HasColumnName("order_id");
    }
