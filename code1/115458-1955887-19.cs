    // This is the only required link between business and data assemblies. 
    // Business is shielded from Data concrete class names and vice-versa. 
    namespace Com.Example.MyProject.Shared {
        public interface ICustomer {
            void SaveToDataSource();
        }
    }
