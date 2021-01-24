    public static class DependencyChainUtil
    {
        public static TypeModel GetDependencyChainForType(Type type)
        {
            var currentChainClassList = new List<string>();
            var model = GetDependencyChainForType(type, currentChainClassList);
            return model;
        }
        private static TypeModel GetDependencyChainForType(Type type, List<string> currentChainClassList)
        {
            if (type != null)
            {
                var model = new TypeModel() {Type = type};
                if (currentChainClassList.Any(x => x == type.FullName))
                {
                    model.IsCircularReference = true;
                }
                else
                {
                    currentChainClassList.Add(type.FullName);
                    var constructorInfo = type.GetConstructors().Where(x => x.GetParameters().Length > 0);
                    foreach (var info in constructorInfo)
                    {
                        foreach (var parameterInfo in info.GetParameters())
                        {
                            var subType = parameterInfo.ParameterType;
                            if (subType.IsInterface)
                            {
                                var types = AppDomain.CurrentDomain.GetAssemblies()
                                    .SelectMany(s => s.GetTypes()).Where(x => x.GetInterfaces().Contains(subType))
                                    .ToList();
                                if (types.Any())
                                {
                                    subType = types.FirstOrDefault();
                                }
                            }
                            model.ConstructorDependencies.Add(GetDependencyChainForType(subType, currentChainClassList));
                        }
                    }
                    currentChainClassList.Remove(type.FullName);
                }
                return model;
            }
            throw new ArgumentNullException("Parameter 'type' is null.");
        }
        public static string OutputTextOfDependencyChain(TypeModel model)
        {
            var output = "";
            var depth = 0;
            if (model != null)
            {
                output = OutputTextOfDependencyChain(model, output, depth);
            }
            return output;
        }
        private static string OutputTextOfDependencyChain(TypeModel model, string output, int depth)
        {
            //prepend depth markers
            output += new String(Enumerable.Range(0, depth*4).SelectMany(x => "-").ToArray());
            output += model.Type.Name;
            output += model.IsCircularReference ? "(CYCLIC DEPENDENCY)" : null;
            output += "<br/>";
            depth++;
            foreach (var typeModel in model.ConstructorDependencies)
            {
                output = OutputTextOfDependencyChain(typeModel, output, depth);
            }
            return output;
        }
    }
    public class TypeModel
    {
        public Type Type { get; set; }
        public List<TypeModel> ConstructorDependencies { get; set; }
        public bool IsCircularReference { get; set; }
        public TypeModel()
        {
            ConstructorDependencies = new List<TypeModel>();
        }
    }
