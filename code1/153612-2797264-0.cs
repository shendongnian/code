    <?xml version="1.0"?>
    <configuration>
        <configSections>
            <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration" />
        </configSections>
        <connectionStrings>
            <add name="SqlConnection" connectionString="data source=(local)\SQLEXPRESS;Integrated Security= SSPI; Initial Catalog= DiaryKeeper;" providerName="System.Data.SqlClient"/>
        </connectionStrings>
        <unity>
            <containers>
                <container>
                    <types>
                        <type type="IRepository`1, ModelProject" mapTo="DALProject.SqlRepository`1, DALProject">
                            <constructor>
                                <param name="connectionString">
                                    <value value="SqlConnection" />
                                </param>
                            </constructor>
                        </type>
                    </types>
                </container>
            </containers>
      </unity>
    </configuration>
