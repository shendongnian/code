    public class ExtraModulesRegister<TConfig> {
        void WithConfig(TConfig config) {}
    }
    // Module method
    public ExtraModulesRegister<TConfig> Module<TConfig>(IModule<TConfig> fakeModule) {
        Return new ExtraModulesRegister<TConfig>();
    }
    // Usage
    register.Module(default(SqlModule)).WithConfig(new SqlConfig()); 
