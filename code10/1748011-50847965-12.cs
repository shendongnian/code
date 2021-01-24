    namespace StructureMap.Unit_Tests.Misc {
        [TestClass]
        public class StructureMapTests {
            [TestMethod]
            public void _Inline_Setter_Should_Populate_Multiple_Implementations() {
                //Arrange
                var registry = new StructureMap.Registry();
                registry.IncludeRegistry<ContainerRegistry>();
                // build a container
                var container = new StructureMap.Container(registry);
    
                //Act
                var application = container.GetInstance<IMeasurementContractsApplication>();
    
                //Assert
                application.Should().NotBeNull();
                application.Foo.Should().BeOfType<Foo>();
                application.Bar.Should().BeOfType<Bar>();
            }
        }
    
        class ContainerRegistry : StructureMap.Registry {
            public ContainerRegistry() {
                Scan(
                    scan => {
                        scan.TheCallingAssembly();
                        scan.WithDefaultConventions();
                        scan.LookForRegistries();
                        scan.AssembliesFromApplicationBaseDirectory(f => f.FullName.StartsWith("Demo.Common", true, null));
                        scan.AssembliesFromApplicationBaseDirectory(f => f.FullName.StartsWith("XXX.MeasurementContracts", true, null));
                        scan.AddAllTypesOf(typeof(IMeasurementContractsApplication));                    
                        scan.AddAllTypesOf(typeof(ITesting));
                        scan.SingleImplementationsOfInterface();
                    });
    
                //Component Providers
                For<IMeasurementContractsApplication>()
                    .Use<MeasurementContractsApplication>()
                    .Setter(x => x.Bar)
                        .Is<Bar>()
                    .Setter(x => x.Foo)
                        .Is<Foo>();
            }
        }
    
        public interface IMeasurementContractsApplication {
            ITesting Foo { get; set; }
            ITesting Bar { get; set; }
        }
    
        public class MeasurementContractsApplication : IMeasurementContractsApplication {
            public ITesting Foo { get; set; }
            public ITesting Bar { get; set; }
        }
    
        public interface ITesting {
            string Name();
        }
    
        public class Foo : ITesting {
            public string Name() {
                return string.Empty;
            }
        }
    
        public class Bar : ITesting {
            public string Name() {
                return string.Empty;
            }
        }
    }
