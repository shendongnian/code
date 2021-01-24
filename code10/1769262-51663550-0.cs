    public class ProfileMobileRoot : Profile
    {
        public ProfileMobileRoot()
        {
            CreateMap<MobileInfo, MobileWidget>()
                .ForMember(x=>x.Name, opt=>opt.MapFrom(x=>x.WidgetName));
            CreateMap<IEnumerable<MobileInfo>, IEnumerable<MobileDashboard>>()
                .ConvertUsing<DashboardConverter>();
            CreateMap<IEnumerable<MobileInfo>, IEnumerable<MobileSolution>>()
                .ConvertUsing<SolutionConverter>();
            CreateMap<IEnumerable<MobileInfo>, IEnumerable<MobileUser>>()
                .ConvertUsing<UserConverter>();
            CreateMap<IEnumerable<MobileInfo>, MobileRoot>()
                .ForMember(x => x.Users, opt => opt.MapFrom(x => x.ToList()));
        }
    }
    class UserConverter : ITypeConverter<IEnumerable<MobileInfo>, IEnumerable<MobileUser>>
    {
        public IEnumerable<MobileUser> Convert(IEnumerable<MobileInfo> source, IEnumerable<MobileUser> destination, ResolutionContext context)
        {
            var groups = source.GroupBy(x => new { x.NameFull, x.EmailAddress});
            foreach (var v in groups)
            {
                yield return new MobileUser()
                {
                    EmailAddress = v.Key.EmailAddress,
                    NameFull = v.Key.NameFull,
                    Solutions = context.Mapper.Map<IEnumerable<MobileSolution>>(source.Where(x =>
                        v.Key.NameFull == x.NameFull && v.Key.EmailAddress== x.EmailAddress)).ToList()
                };
            }
        }
    }
    class SolutionConverter : ITypeConverter<IEnumerable<MobileInfo>, IEnumerable<MobileSolution>>
    {
        public IEnumerable<MobileSolution> Convert(IEnumerable<MobileInfo> source, IEnumerable<MobileSolution> destination, ResolutionContext context)
        {
            var groups = source.GroupBy(x => new { x.SolutionName, x.SortOrder});
            foreach (var v in groups)
            {
                yield return new MobileSolution()
                {
                    Solution = v.Key.SolutionName,
                    SortOrder = v.Key.SortOrder,
                    Dashboards= context.Mapper.Map<IEnumerable<MobileDashboard>>(source.Where(x =>
                        v.Key.SolutionName== x.SolutionName&& v.Key.SortOrder== x.SortOrder)).ToList()
                };
            }
        }
    }
    class DashboardConverter : ITypeConverter<IEnumerable<MobileInfo>, IEnumerable<MobileDashboard>>
    {
        public IEnumerable<MobileDashboard> Convert(IEnumerable<MobileInfo> source, IEnumerable<MobileDashboard> destination, ResolutionContext context)
        {
            var groups = source.GroupBy(x => new {x.Name, x.IsLegacy, x.Description});
            foreach (var v in groups)
            {
                yield return new MobileDashboard()
                {
                    Dashboard = v.Key.Name,
                    Description = v.Key.Description,
                    IsLegacy = v.Key.IsLegacy,
                    Widgets = context.Mapper.Map<IEnumerable<MobileWidget>>(source.Where(x =>
                        v.Key.IsLegacy == x.IsLegacy && v.Key.Name == x.Name && v.Key.Description == x.Description))
                };
            }
        }
    }
