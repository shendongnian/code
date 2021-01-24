    builder.Entity<Image>().HasOne(u => u.ApplicationUser)
                           .WithMany(i => i.Images)
                           .HasForeignKey(u => u.ApplicationUserId)
                           .HasConstraintName
                                (
                                  "FK_Image_AspNetUsers_ApplicationUserId"
                                );
    builder.Entity<Video>().HasOne(u => u.ApplicationUser)
                           .WithMany(p => p.Videos)
                           .HasForeignKey(u => u.ApplicationUserId)
                           .HasConstraintName
                                     (
                                      "FK_Video_AspNetUsers_ApplicationUserId"
                                     );
    builder.Entity<Audio>().HasOne(u => u.ApplicationUser)
                           .WithMany(p => p.Audios)
                           .HasForeignKey(u => u.ApplicationUserId)                                    
                           .HasConstraintName
                                 (
                                   "FK_Audio_AspNetUsers_ApplicationUserId"
                                 );
