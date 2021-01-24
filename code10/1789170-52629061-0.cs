    public interface IUnitOfWork
        {
            IGenericRepository<Amendment> AmendmentRepository { get; }
            IGenericRepository<Credit> CreditRepository { get; }
            IGenericRepository<FileUpload> FileUploadRepository { get; }
            IGenericRepository<Job> JobRepository { get; }
            IGenericRepository<Subscription> SubscriptionRepository { get; }
            IGenericRepository<Topic> TopicRepository { get; }
            IGenericRepository<Writer> WriterRepository { get; }
    
            void Dispose();
            void Save();
        }
