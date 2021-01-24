    public class TaskAppService : AsyncCrudAppService<Host, HostDto, int, PagedResultRequestDto, CreateHostDto, HostDto>, IHostsAppService
    {
    
    //...
        protected override IQueryable<Task> CreateFilteredQuery(GetAllTasksInput input)
        {
            return base.CreateFilteredQuery(input).Include(x=>x.HostLines);
        }
    
    //...
    
    }
