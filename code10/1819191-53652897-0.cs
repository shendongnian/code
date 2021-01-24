        modelBuilder.Entity<A>(entity =>
              {
        		entity.Property(e => e.Id).ValueGeneratedOnAdd()
                entity.ToTable("A");
        		entity.Property(e => e.Name)
                    });
          modelBuilder.Entity<B>(entity =>
                    {
        
        	   entity.Property(e => e.Id).ValueGeneratedOnAdd()
               entity.ToTable("B");
               entity.HasOne(d => d.A)
                            .WithMany(p => p.B)
                            .HasForeignKey(d => d.TableARowId)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_B_ToA");
                    });
