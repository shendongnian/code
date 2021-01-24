      public class RequestConfiguration : EntityTypeConfiguration<RequestModel>
    {
        public RequestConfiguration()
        {
            ToTable("QMS_REQUESTS").HasKey(p =>p.Id);
            Property(p => p.Id).HasColumnName("REQUEST_ID").IsRequired();
            Property(p => p.RequestTypeId).HasColumnName("REQUEST_TYPE_ID");
            Property(p => p.RequestData).HasColumnName("REQUEST_DATA").HasMaxLength(800);
            Property(p => p.RequestResult).HasColumnName("REQUEST_RESULT").HasMaxLength(150);
            Property(p => p.RequestStatusId).HasColumnName("REQUEST_STATUS_ID");
            Property(p => p.Created).HasColumnName("REQUEST_CREATED").HasMaxLength(50);
            Property(p => p.RequestIsActive).HasColumnName("REQUEST_IsActive");
            Property(p => p.FromUserId).HasColumnName("FROM_USER");
            Property(p => p.ToUserId).HasColumnName("TO_USER");
        }
    }
    public class RequestViewConfiguration : EntityTypeConfiguration<RequestView>
    {
        public RequestViewConfiguration()
        {
            ToTable("VIEW_QMS_REQUESTS").HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("REQUEST_ID").IsRequired();
            Property(p => p.RequestTypeId).HasColumnName("REQUEST_TYPE_ID");
            Property(p => p.RequestTypeName).HasColumnName("REQUEST_TYPE_NAME");
            Property(p => p.RequestStatusId).HasColumnName("REQUEST_STATUS_ID");
            Property(p => p.RequestStatusName).HasColumnName("REQUEST_STATUS_NAME");
            Property(p => p.RequestResult).HasColumnName("REQUEST_RESULT").HasMaxLength(150);
            Property(p => p.Created).HasColumnName("REQUEST_CREATED").HasMaxLength(50);
            Property(p => p.RequestIsActive).HasColumnName("REQUEST_IsActive");
            Property(p => p.FromUserId).HasColumnName("FROM_USER");
            Property(p => p.FromUserName).HasColumnName("FROM_USERNAME");
            Property(p => p.ToUserId).HasColumnName("TO_USER");
            Property(p => p.ToUserName).HasColumnName("TO_USERNAME");
        }
    }
