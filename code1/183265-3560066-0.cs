    public class AutoMapViewResult<TSource, TDestination> : ViewResult
    {
        public AutoMapViewResult(string viewName, string masterName, object model)
        {
            ViewName = viewName;
            MasterName = masterName;
            if (model.GetType().IsArray)
            {
                var viewModel = new List<TDestination>();
                foreach (var item in (TSource[])model)
                {
                    viewModel.Add(Mapper.Map<TSource, TDestination>(item));
                }
                ViewData.Model = viewModel.ToArray();
            }
            else if (model.GetType().IsGenericType)
            {
                var viewModel = new List<TDestination>();
                foreach (var item in (IEnumerable<TSource>)model)
                {
                    viewModel.Add(Mapper.Map<TSource, TDestination>(item));
                }
                ViewData.Model = viewModel;
            }
            else
            {
                ViewData.Model = Mapper.Map<TSource, TDestination>((TSource)model, IoC.Resolve<TDestination>());
            }
        }
    }
