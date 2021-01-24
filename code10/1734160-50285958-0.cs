    var allSubClasses = Assembly
                    .GetAssembly(typeof(BaseViewModel))
                    .GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(BaseViewModel)));
    
                foreach (var item in allSubClasses)
                {
                    var attributes = item.GetCustomAttributes(typeof(DataContractAttribute), false);
    
                    var dataContractAttribute = attributes[0] as DataContractAttribute;
    
                    string dataContractName = dataContractAttribute.Name;
                }
