    modelBuilder.Entity<Side>.ToTable("Sides")
                .HasDiscriminator<SideType>("SideType")
                .HasValue<A>(SideType.BASE_A)
                .HasValue<B>(SideType.BASE_A);
 
     public enum SideType {
        BASE_A = 100,
        BASE_B = 500
     }
                
