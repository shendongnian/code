    modelBuilder.Entity<ProductConfig>()
            .Property(e => e.Category)
            .HasColumnAnnotation(
                IndexAnnotation.AnnotationName, 
                new IndexAnnotation(new IndexAttribute("YourIndex", 1) { IsUnique = true }));
    
    modelBuilder.Entity<ProductConfig>()
            .Property(e => e.Product)
            .HasColumnAnnotation(
                IndexAnnotation.AnnotationName, 
                new IndexAnnotation(new IndexAttribute("YourIndex", 2) { IsUnique = true }));
    
    modelBuilder.Entity<ProductConfig>()
            .Property(e => e.ProductCategoryType)
            .HasColumnAnnotation(
                IndexAnnotation.AnnotationName, 
                new IndexAnnotation(new IndexAttribute("YourIndex", 3) { IsUnique = true }));
