    protected overrid void OnModelCreating(...)
    {
         // Every VmWordLocalization has a property Key, which is unique per VmWordId
         // create an index with (VmWordId, Key) as index key
         var vmWordLocalizationEntity = modelBuilder.Entity<VmWordLocalization>();
         // first index annotation: VmWordId:
         vmWordLocalizationEntity.Property(entity => entity.VmWordId)
             .IsRequired()
             .HasColumnAnnotatin(IndexAnnotation.AnnotationName, 
                  new IndexAnnotation(new IndexAttribute("index_VmWordId", 0)));
         // 2nd index annotation: Key:
         vmWordLocalizationEntity.Property(entity => entity.Key)
             .IsRequired()
             .HasColumnAnnotatin(IndexAnnotation.AnnotationName, 
                  new IndexAnnotation(new IndexAttribute("index_Key", 1)));
    }
