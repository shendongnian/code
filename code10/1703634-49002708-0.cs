    public class TB_R_LEAVE_REQ_ID_Configuration : EntityTypeConfiguration<Entities.TB_R_LEAVE_REQ_ID>
    {
        public TB_R_LEAVE_REQ_ID_Configuration()
        {
            ToTable("TB_R_LEAVE_REQ_ID");
            
            HasKey(e => e.LEAVE_REQ_ID);
            HasRequired<TB_R_LEAVE_REQ>(e => e.TB_R_LEAVE_REQ);
            Ignore(e => e.UPDATED_BY);
            Ignore(e => e.UPDATED_DT);
            Ignore(e => e.CREATED_BY);
            Ignore(e => e.CREATED_DT);
            Property(e => e.LEAVE_REQ_ID).HasColumnName("LEAVE_REQ_ID").HasMaxLength(10);
            Property(e => e.LEAVE_ID).HasColumnName("LEAVE_ID").HasMaxLength(5);
        }
    }
