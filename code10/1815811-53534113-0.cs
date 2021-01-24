        public class ParameterTypeFilter: TypeFilterAttribute
        {
            public ParameterTypeFilter(string para1, string para2):base(typeof(ParameterActionFilter))
            {
                Arguments = new object[] { para1, para2 };
            }
        }
