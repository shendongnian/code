    <castle>
    <properties>
            <dev>Data Source=COMPUTERNAME\SQL2008;Initial Catalog=MyDB;Persist Security Info=True;User ID=username;Password=password</dev>
            <stage>Data Source=COMPUTERNAME\SQL2008;Initial Catalog=MyDB;Persist Security Info=True;User ID=username;Password=password</stage>
            <production>Data Source=COMPUTERNAME\SQL2008;Initial Catalog=MyDB;Persist Security Info=True;User ID=username;Password=password</production>
    </properties>
    <components>
            <component id="MyRepository" service="DomainModel.Abstract.IMyRepository, DomainModel" type="DomainModel.Concrete.MyRepository, DomainModel" lifestyle="PerWebRequest">
                <parameters>
                    <connectionString>#{dev|stage|production}</connectionString>
                </parameters>
            </component>
    </components>
