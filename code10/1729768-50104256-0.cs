        public class ProjectManager : IProjectFactory
        {
            private readonly ILifetimeScope _scope;
            public ProjectManager(ILifetimeScope scope)
            {
                // this is going to be the global scope.
                _scope = scope;
            }
            public Project OpenProject(IDocumentFactory docFactory, IProjectSettings settings)
            {
                var projectScope = _scope.BeginLifetimeScope("project");
                projectScope.RegisterInstance(docFactory).AsImplementedInterfaces();
                projectScope.RegisterInstance(settings).AsImplementedInterfaces();
                return projectScope.Resolve<Project>();
            }
        }
        public class ProjectScope : IDisposable
        {
            private readonly ILifetimeScope _scope;
            public ProjectManager(ILifetimeScope scope)
            {
                // this is going to be the project scope.
                _scope = scope;
            }
            public void Dispose() {
                if (_scope != null) {
                    _scope.Dispose();
                    _scope = null;
                }
            }
        }
        public class Project : IDisposable
        {
            private readonly ProjectScope _scope; 
            public Project(ProjectScope scope /*, ...*/)
            {
                _scope = scope;
            }
            public void Dispose() {
                // pay attention that this method will be called 2 times, once by you
                // and another time by the underlying LifetimeScope. So this code should
                // handle that gracefully (so the _scope == null).
                if (_scope != null) {
                    _scope.Dispose();
                    _scope = null;
                }
            }
        }
