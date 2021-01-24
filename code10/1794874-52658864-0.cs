    namespace EbicogluSoftware.Forum.Threads
    {
        [Table("Threads")]
        public class Thread : FullAuditedEntity
        {
            [Required]
            [StringLength(500)]
            public virtual string Title { get; set; }
    
            [Required]
            [StringLength(2000)]
            public virtual string Text { get; set; }
    
            public virtual List<Post> Posts { get; set; }
    
            public Thread()
            {
                Posts = new List<Post>();
            }
        }
    
        [Table("Posts")]
        public class Post : FullAuditedEntity
        {
            [Required]
            [StringLength(2000)]
            public virtual string Text { get; set; }
        }
    
        public class ThreadDto
        {
            public string Title { get; set; }
    
            public string Text { get; set; }
    
            public List<PostDto> Posts { get; set; }
    
            public ThreadDto()
            {
                Posts = new List<PostDto>();
            }
        }
    
        public class PostDto
        {
            public string Text { get; set; }
        }
    
        public class ThreadAppService : IApplicationService
        {
            private readonly IRepository<Thread> _threadRepository;
    
            public ThreadAppService(IRepository<Thread> threadRepository)
            {
                _threadRepository = threadRepository;
            }
    
            public async Task<List<TenantListDto>> GetThreads()
            {
                var threads = await _threadRepository.GetAllIncluding(x => x.Posts).ToListAsync();
                return threads.MapTo<List<TenantListDto>>();
            }
        }
    }
