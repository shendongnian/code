    var solvers = Assembly.GetAssembly(typeof(Matrix<double>))
        .GetTypes()
        .Where(t => t.GetInterfaces().Contains(typeof(IIterativeSolver<double>)) &&
                    t.GetConstructors().Any(ctor => ctor.GetParameters().Count() == 0))
        .Select(t => Activator.CreateInstance(t))
        .Cast<IIterativeSolver<double>>();
