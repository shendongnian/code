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
            var target = container.GetInstance<IMeasurementContractsApplication>();
            //Assert
            target.Should().NotBeNull();
            target.DistributionListProvider.Should().BeOfType<DistributionListProvider>();
            target.FirstDeliveryNoticeDocumentRecallProvider.Should().BeOfType<FirstDeliveryNoticeDocumentAdminUpdateProvider>();
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
                    scan.AssembliesFromApplicationBaseDirectory(f => f.FullName.StartsWith("XXX.XXX.MeasurementContracts", true, null));
                    scan.AddAllTypesOf(typeof(IMeasurementContractsApplication));
                    scan.AddAllTypesOf(typeof(IInstanceProvider));
                    scan.SingleImplementationsOfInterface();
                });
            // --------
            // APPLICATION
            For<IMeasurementContractsApplication>()
                .Use<MeasurementContractsApplication>()
                // Component
                .Setter(x => x.DistributionListProvider)
                    .Is<DistributionListProvider>()
                .Setter(x => x.FirstDeliveryNoticeDocumentRecallProvider)
                    .Is<FirstDeliveryNoticeDocumentAdminUpdateProvider>();
        }
    }
    public interface IMeasurementContractsApplication {
        IInstanceProvider DistributionListProvider { get; set; }
        IInstanceProvider FirstDeliveryNoticeDocumentRecallProvider { get; set; }
    }
    public class MeasurementContractsApplication : IMeasurementContractsApplication {
        public IInstanceProvider DistributionListProvider { get; set; }
        public IInstanceProvider FirstDeliveryNoticeDocumentRecallProvider { get; set; }
    }
    public interface IInstanceProvider {
    }
    public class DistributionListProvider : IInstanceProvider {
        // Purposely left-out Properties, Methods etc.
    }
    public class FirstDeliveryNoticeDocumentAdminUpdateProvider : IInstanceProvider {
        // Purposely left-out Properties, Methods etc.
    }
